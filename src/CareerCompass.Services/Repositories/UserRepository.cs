using CareerCompass.DataContext;
using CareerCompass.DataContext.Entities;
using CareerCompass.Services.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CareerCompass.Services.Repositories
{
    public class UserRepository
        : IUserRepository
    {
        private readonly DatabaseContext dbContext;

        public UserRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<User?> GetByEmail(string email, CancellationToken token = default)
            => dbContext.Users
                .Include(x => x.SchoolYears)
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower(), token);

        public Task<User?> GetById(int userId, CancellationToken token = default)
            => dbContext.Users
                .Include(x => x.SchoolYears)
                .FirstOrDefaultAsync(u => u.Id == userId, token);

        public async Task InsertAsync(User user, CancellationToken token = default)
            => await dbContext.Users.AddAsync(user, token);
    }
}
