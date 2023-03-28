namespace Veranda.Common.DomainEvents.Abstractions;

public interface IDomainEvent
{
    Guid PublicId { get; set; }
}
