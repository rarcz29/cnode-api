using CNode.Application.Common.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CNode.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options
                    .UseNpgsql(configuration.GetConnectionString("LocalDb"))
                    .UseLoggerFactory(
                        LoggerFactory
                            .Create(builder => builder.AddConsole()
                            .AddFilter((category, level)
                                => category == DbLoggerCategory.Database.Command.Name
                                && level == LogLevel.Information)))
                    .EnableSensitiveDataLogging()
                    .UseSnakeCaseNamingConvention();
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
