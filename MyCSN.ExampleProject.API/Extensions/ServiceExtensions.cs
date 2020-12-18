using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCSN.ExampleProject.Data;

namespace MyCSN.ExampleProject.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options => {
                options?.AddPolicy("CorsPolicy", builder => {
                    builder?.AllowAnyOrigin()
                           ?.AllowAnyMethod()
                           ?.AllowAnyHeader();
                });
            });

        public static void ConfigureDatabaseContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<WeatherDbContext>(options => {
                options.UseNpgsql(configuration.GetConnectionString("default"));
                options.EnableSensitiveDataLogging();
            });

        public static void ConfigureResponseCompression(this IServiceCollection services) =>
            services.AddResponseCompression(options => {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
                options.Providers.Add<BrotliCompressionProvider>();
            });
    }
}