using CareerCompass.DataContext;
using CareerCompass.DataContext.Entities;
using CareerCompass.Services.Abstractions.Repositories;
using CareerCompass.Services.Abstractions.Services;
using CareerCompass.Services.Models.Auth;

namespace CareerCompass.Services.Services
{
    public class UserService
        : BaseService, IUserService
    {
        private readonly IUserRepository repository;
        private readonly ICryptographyService cryptographyService;

        public UserService(
            DatabaseContext dbContext,
            IUserRepository repository,
            ICryptographyService cryptographyService)
            : base(dbContext)
        {
            this.repository = repository;
            this.cryptographyService = cryptographyService;
        }

        public async Task<User> Register(Register model)
        {
            var existingUser = await repository.GetByEmail(model.Email);

            if (existingUser is not null)
            {
                throw new InvalidOperationException($"A user with email {model.Email} already exists");
            }

            var (encryptedPassword, salt) = EncryptPassword(model.Password);
            var user = model.ToUser(encryptedPassword, salt);

            await repository.InsertAsync(user);
            await SaveChangesAsync();

            return user;
        }

        private (string Password, string Salt) EncryptPassword(string password)
        {
            var salt = cryptographyService.GenerateRandomSalt();
            var encryptedPassword = cryptographyService.EncryptHash(password, salt);

            return (encryptedPassword, Convert.ToBase64String(salt));
        }
    }
}
