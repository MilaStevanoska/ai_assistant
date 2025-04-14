using CareerCompass.Services.Abstractions.Services;
using CareerCompass.Services.Models.Configurations;
using CareerCompass.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CareerCompass.Api.Infrastructure.Startup
{
    public static class AuthenticationConfig
    {
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSection = configuration.GetSection("JWT");
            services.Configure<JwtSettings>(jwtSection);

            var jwtSettings = jwtSection.Get<JwtSettings?>();

            if (jwtSettings is null)
            {
                throw new Exception("Missing jwt settings in configuration");
            }

            var keyBytes = Encoding.UTF8.GetBytes(jwtSettings!.Key);

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            if (string.IsNullOrEmpty(context.Token))
                            {
                                context.Token = context.Request.Cookies["jwt"];
                            }
                            return Task.CompletedTask;
                        }
                    };
                });

            services
                .AddTransient<IAuthService, AuthService>()
                .AddTransient<ICryptographyService, CryptographyService>()
                .AddTransient<IJwtService, JwtService>();

            return services;
        }

        public static IApplicationBuilder UseAuthenticationConfiguration(this IApplicationBuilder application)
            => application
                .UseAuthentication()
                .UseAuthorization();
    }
}
