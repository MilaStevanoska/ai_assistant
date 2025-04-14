using CareerCompass.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CareerCompass.Api.Infrastructure.Startup
{
    public static class DataContextConfig
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            var connectionString = configuration.GetConnectionString("CareerCompassDbConnection") ?? throw new ArgumentNullException("Connection string should not be null");

            services
                .AddDbContext<DatabaseContext>((provider, options) =>
                {
                    options
                        .EnableDetailedErrors(environment.IsDevelopment())
                        .EnableSensitiveDataLogging(!environment.IsProduction())
                        .UseSqlServer(connectionString, server =>
                        {
                            var assembly = Assembly.GetAssembly(typeof(DatabaseContext));

                            if (assembly != null)
                            {
                                server.MigrationsAssembly(assembly.FullName);
                            }

                            server.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                        })
                        .UseLoggerFactory(provider.GetRequiredService<ILoggerFactory>());
                }, ServiceLifetime.Scoped, ServiceLifetime.Singleton);

            return services;
        }

        public static async Task ApplyMigrations(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateAsyncScope())
            {
                var dbContext = scope.ServiceProvider.GetService<DatabaseContext>() ?? throw new ArgumentNullException("DbContext should not be null");
                var logger = scope.ServiceProvider.GetService<ILogger>() ?? throw new ArgumentNullException("Logger should not be null");
                var pendingMigrations = GetPendingMigrations(dbContext);

                if (pendingMigrations.Any())
                {
                    await dbContext.Database.MigrateAsync();
                    logger.LogInformation("Migrated to latest version {Version}", dbContext.GetLatestVersion());
                }
            }
        }

        private static IEnumerable<string> GetPendingMigrations(this DbContext dbContext)
        {
            try
            {
                return dbContext.Database.GetPendingMigrations();
            }
            catch
            {
                return Enumerable.Empty<string>();
            }
        }

        private static string GetLatestVersion(this DbContext dbContext)
            => dbContext.Database.GetAppliedMigrations().LastOrDefault() ?? string.Empty;
    }
}
