using CareerCompass.DataContext.Entities;

namespace CareerCompass.Services.Abstractions.Services
{
    public interface IJwtService
    {
        (string Token, int? ExpiryInMinutes) CreateToken(User user);
    }
}
