namespace CareerCompass.Api.Infrastructure.Startup
{
    public static class LoggingConfig
    {
        public static IServiceCollection ConfigureLogging(this IServiceCollection services)
        {
            services.AddLogging();
            services.AddSingleton<ILogger>(provider =>
            {
                return provider.GetRequiredService<ILogger<Program>>();
            });

            return services;
        }
    }
}
