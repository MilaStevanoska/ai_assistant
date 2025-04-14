using CareerCompass.DataContext.Entities;
using CareerCompass.Services.Models.Auth;

namespace CareerCompass.Services.Abstractions.Services
{
    public interface IUserService
    {
        Task<User> Register(Register model);
    }
}
