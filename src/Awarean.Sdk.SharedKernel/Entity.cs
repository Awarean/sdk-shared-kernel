using Awarean.Sdk.SharedKernel;
using Awarean.Sdk.SharedKernel.Events;

namespace Awaren.Sdk.SharedKernel
{
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public virtual TKey Id { get; protected set; }

        public event EntityUpdated OnUpdate;

        protected virtual void ExecuteUpdate<T>(IEntity<T> updater, DateTime? updateDate = null)
        {
            OnUpdate?.Invoke(this, new EntityUpdatedEventArgs(updater, updateDate ?? DateTime.Now));
        }
    }

}