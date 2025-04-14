using System.Runtime.Serialization;
using System.Security.Principal;

namespace CareerCompass.Services.Abstractions.Models
{
    public interface IRolePrincipal
        : IPrincipal, ISerializable
    {
        int Id { get; set; }

        string Name { get; set; }

        string Email { get; set; }
    }
}
