using CareerCompass.DataContext.Entities;

namespace CareerCompass.Services.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetById(int userId, CancellationToken token = default);

        Task<User?> GetByEmail(string email, CancellationToken token = default);

        Task InsertAsync(User user, CancellationToken token = default);

    }
}
