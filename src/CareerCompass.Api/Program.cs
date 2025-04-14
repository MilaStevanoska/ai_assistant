using CareerCompass.Api.Infrastructure.Startup;
using CareerCompass.Api.Middlewares;

namespace CareerCompass.Api
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services
                .ConfigureDbContext(builder.Configuration, builder.Environment);

            builder.Services
                .ConfigureLogging()
                .ConfigureServices()
                .ConfigureRepositories()
                .ConfigureValidators()
                .ConfigureCors();

            builder.Services
                .ConfigureAuthentication(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseAuthenticationConfiguration();

            if (app.Environment.IsDevelopment())
            {
                app.UseCors("AllowLocalhost");
            }
            else
            {
                app.UseCors("AllowProductionFrontend");
            }

            await app.Services.ApplyMigrations();

            app.MapControllers();

            app.Run();
        }
    }
}
