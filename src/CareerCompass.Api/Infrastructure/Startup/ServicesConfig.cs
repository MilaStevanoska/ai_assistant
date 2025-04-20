using CareerCompass.Services.Abstractions.Services;
using CareerCompass.Services.Services;

namespace CareerCompass.Api.Infrastructure.Startup
{
    public static class ServicesConfig
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMasterDataService, MasterDataService>();
            return services;
        }
    }
}
