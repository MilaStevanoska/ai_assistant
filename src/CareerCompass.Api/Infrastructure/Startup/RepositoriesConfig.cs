using CareerCompass.Services.Abstractions.Repositories;
using CareerCompass.Services.Repositories;

namespace CareerCompass.Api.Infrastructure.Startup
{
    public static class RepositoriesConfig
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}
