using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Veranda.Common.Database;
using Veranda.Common.Options;

namespace Veranda.Common.Configuration;
public static class DataConfigurationExtensions
{
    public static IServiceCollection AddPostgres<TDbContext>(this IServiceCollection services, IConfiguration configuration) where TDbContext : ServiceDbContext
    {
        services.AddServiceOptions<DbOptions>(configuration);
        services.AddDbContext<TDbContext>((serviceProvider, options) =>
        {
            var dbOptions = serviceProvider.GetRequiredService<IOptions<DbOptions>>();
            options.UseSnakeCaseNamingConvention();
            options.UseNpgsql(dbOptions.Value.ConnectionString);
        });
        return services;
    }
}
