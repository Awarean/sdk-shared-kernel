namespace Awarean.Sdk.SharedKernel;

public interface IAuditableEntity<out TKey> : IEntity<TKey>
{
    DateTime CreatedAt { get; }
    DateTime UpdatedAt { get; }
    string UpdatedBy { get; }
}
