using CareerCompass.DataContext.Entities;

namespace CareerCompass.Services.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetById(int userId);

        Task<User?> GetByEmail(string email);

        Task InsertAsync(User user);
    }
}
