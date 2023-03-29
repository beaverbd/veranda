using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Veranda.Common.Options.OptionsValidator;

namespace Veranda.Common.Options;
public static class OptionsExtensions
{
    public static void AddServiceOptions<TOptions>(this IServiceCollection services, IConfiguration configuration) where TOptions : class, IServiceOptions
    {
        var instance = Activator.CreateInstance<TOptions>();
        services.AddOptions<TOptions>()
                    .Bind(configuration.GetSection(instance.Name))
                    .ValidateOptions()
                    .ValidateOnStart();
    }
}
