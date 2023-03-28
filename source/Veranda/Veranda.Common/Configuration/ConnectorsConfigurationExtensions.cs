using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Veranda.Common.Configuration;
public static class ConnectorsConfigurationExtensions
{
    public static void AddGrpcClientsConfig(this IConfigurationBuilder configurationBuilder, IWebHostEnvironment environment)
    {
        configurationBuilder
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile($"Connectors/connectors.{environment.EnvironmentName}.json");
    }

    public static IServiceCollection AddUsersConnector(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddGrpcClient<GrpcUsersService.Users.UsersClient>(options =>
        {
            options.Address = new Uri(configuration["UsersUrl"]!);
        });
        return services;
    }
}
