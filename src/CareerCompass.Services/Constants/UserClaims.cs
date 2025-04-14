using System.Security.Claims;

namespace CareerCompass.Services.Constants
{
    public static class UserClaims
    {
        public const string FirstName = "firstName";

        public const string LastName = "lastName";

        public const string Email = ClaimTypes.Email;
    }
}
