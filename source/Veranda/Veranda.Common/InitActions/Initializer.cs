using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Veranda.Common.InitActions.Abstractions;

namespace Veranda.Common.InitActions;
public class Initializer : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public Initializer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        Log.Information("Start initialization...");

        using var scope = _serviceProvider.CreateScope();
        foreach (var initializer in scope.ServiceProvider.GetServices<IInitAction>()
                     .OrderByDescending(x => x.Priority))
        {
            await initializer.Initialize(scope, cancellationToken);
        }

        Log.Information("Initialization finished successfully!");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
