using Microsoft.Extensions.DependencyInjection;

namespace Veranda.Common.InitActions.Abstractions;
public interface IInitAction
{
    int Priority { get; }
    Task Initialize(IServiceScope serviceScope, CancellationToken cancellationToken);
}
