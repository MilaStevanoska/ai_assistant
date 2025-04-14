using CareerCompass.Services.Models.Auth;
using CareerCompass.Services.Validation;
using FluentValidation;

namespace CareerCompass.Api.Infrastructure.Startup
{
    public static class ValidationConfig
    {
        public static IServiceCollection ConfigureValidators(this IServiceCollection services)
        {
            services
                .AddTransient<IValidator<Login>, LoginValidator>()
                .AddTransient<IValidator<Register>, RegisterValidator>();

            return services;
        }
    }
}
