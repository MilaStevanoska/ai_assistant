using CareerCompass.DataContext.Entities;
using CareerCompass.Services.Abstractions.Models;
using CareerCompass.Services.Abstractions.Services;
using CareerCompass.Services.Constants;
using CareerCompass.Services.Models.Configurations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CareerCompass.Services.Services
{
    public class JwtService
        : IJwtService
    {
        private readonly JwtSettings jwtSettings;
        private readonly ILogger<JwtService> logger;

        public JwtService(IOptions<JwtSettings> jwtSettings, ILogger<JwtService> logger)
        {
            this.jwtSettings = jwtSettings.Value;
            this.logger = logger;
        }

        public (string Token, int? ExpiryInMinutes) CreateToken(User user)
        {
            try
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(UserClaims.FirstName, user.FirstName),
                    new Claim(UserClaims.LastName, user.LastName),
                    new Claim(UserClaims.Email, user.Email)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: jwtSettings.Issuer,
                    audience: jwtSettings.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.ExpiresInMinutes)),
                    signingCredentials: creds);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return (tokenString, jwtSettings.ExpiresInMinutes);
            }
            catch (Exception ex)
            {
                logger.LogError($"An error occurred while creating jwt token for user {user.Id}", ex);
                throw;
            }
        }
    }
}
