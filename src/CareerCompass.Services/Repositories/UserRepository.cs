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

        public Task<User?> GetByEmail(string email)
            => dbContext.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());

        public Task<User?> GetById(int userId)
            => dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

        public async Task InsertAsync(User user)
            => await dbContext.Users.AddAsync(user);
    }
}
