using CareerCompass.Services.Abstractions.Models;
using CareerCompass.Services.Constants;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Security.Principal;

namespace CareerCompass.Services.Models.Principal
{
    public class ClaimsPrincipalWrapper
        : IRolePrincipal
    {
        private readonly ClaimsPrincipal principal;

        public ClaimsPrincipalWrapper(ClaimsPrincipal principal)
        {
            this.principal = principal;

            var id = Helper.GetClaim<string?>(principal, ClaimTypes.NameIdentifier);

            Id = Convert.ToInt32(id);

            var firstName = Helper.GetClaim<string>(principal, UserClaims.FirstName);
            var lastName = Helper.GetClaim<string>(principal, UserClaims.LastName);

            Name = $"{firstName} {lastName}";
            Email = Helper.GetClaim<string>(principal, UserClaims.Email);
        }

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public IIdentity? Identity => principal.Identity;

        public void GetObjectData(SerializationInfo info, StreamingContext context) => throw new NotImplementedException();

        public bool IsInRole(string role) => throw new NotImplementedException();

        private static class Helper
        {
            public static bool HasClaim<T>(ClaimsPrincipal principal, string claim, out T result)
            {
                result = default!;

                if (principal.HasClaim(x => x.Type == claim))
                {
                    try
                    {
                        result = Cast<T>(principal, claim);
                        return true;
                    }
                    catch (InvalidCastException) { }
                }

                return false;
            }

            public static T GetClaim<T>(ClaimsPrincipal principal, string claim)
            {
                if (principal.HasClaim(x => x.Type == claim))
                {
                    try
                    {
                        return Cast<T>(principal, claim);
                    }
                    catch (InvalidCastException) { }
                }

                return default!;
            }

            private static T Cast<T>(ClaimsPrincipal principal, string claim) => (T)Convert.ChangeType(principal.FindFirst(claim)!.Value, Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T));
        }
    }
}
