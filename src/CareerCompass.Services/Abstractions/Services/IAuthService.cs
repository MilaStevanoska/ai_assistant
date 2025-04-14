using CareerCompass.DataContext.Entities;

namespace CareerCompass.Services.Abstractions.Services
{
    public interface IAuthService
    {
        Task<User?> AuthenticateWithEmailAndPassword(string email, string password);
    }
}
