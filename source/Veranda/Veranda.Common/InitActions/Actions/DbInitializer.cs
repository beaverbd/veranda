using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Veranda.Common.Database;
using Veranda.Common.InitActions.Abstractions;

namespace Veranda.Common.InitActions.Actions;

public class DbInitializer<TDbContext> : IInitAction where TDbContext : ServiceDbContext
{
    public int Priority => int.MaxValue;

    public async Task Initialize(IServiceScope serviceScope, CancellationToken cancellationToken)
    {
        Log.Information("Initialize database.");
        var dbContext = serviceScope.ServiceProvider.GetRequiredService<TDbContext>();
        await dbContext.Database.MigrateAsync(cancellationToken);
    }
}
