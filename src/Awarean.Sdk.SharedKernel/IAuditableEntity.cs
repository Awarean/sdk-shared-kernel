namespace Awaren.Sdk.SharedKernel
{
    public interface IAuditableEntity<out TKey> : IEntity<TKey>
    {
        DateTime CreatedAt { get; }
        DateTime UpdatedAt { get; }
        IEntity LastUpdater { get; }
        void Update<T>(IEntity<T> updater);
    }
}