using Awarean.Sdk.SharedKernel.Events;

namespace Awarean.Sdk.SharedKernel;

public abstract class Entity<TKey> : IEntity<TKey>
{
    public virtual TKey Id { get; protected set; }

    public event EntityUpdated OnUpdate;

    protected virtual void ExecuteUpdate(string UpdatedBy, DateTime? updateDate = null)
    {
        OnUpdate?.Invoke(this, new EntityUpdatedEventArgs(UpdatedBy, updateDate ?? DateTime.Now));
    }
}