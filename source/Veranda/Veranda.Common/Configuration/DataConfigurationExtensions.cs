using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Veranda.Common.Database;

namespace Veranda.Common.Configuration;
public static class DataConfigurationExtensions
{
    public static IServiceCollection AddPostgres<T>(this IServiceCollection services,
        string connectionString) where T : ServiceDbContext
    {
        services.AddDbContext<T>(options =>
        {
            options.UseSnakeCaseNamingConvention();
            options.UseNpgsql(connectionString);
        });
        return services;
    }
}
