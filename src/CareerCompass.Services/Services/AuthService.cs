using CareerCompass.DataContext.Entities;
using CareerCompass.Services.Abstractions.Repositories;
using CareerCompass.Services.Abstractions.Services;
using System.Text;

namespace CareerCompass.Services.Services
{

    public class AuthService
        : IAuthService
    {
        private readonly IUserRepository userRepository;
        private readonly ICryptographyService cryptographyService;

        public AuthService(
            IUserRepository userRepository,
            ICryptographyService cryptographyService)
        {
            this.userRepository = userRepository;
            this.cryptographyService = cryptographyService;
        }

        public async Task<User?> AuthenticateWithEmailAndPassword(string email, string password)
        {
            var user = await userRepository.GetByEmail(email);

            if (user is null)
            {
                return null;
            }

            if (cryptographyService.VerifyHash(password, user.Password, user.Salt))
            {
                return user;
            }

            return null;
        }
    }
}
