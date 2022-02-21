using Awarean.Sdk.SharedKernel;
using Awarean.Sdk.SharedKernel.Events;

namespace Awaren.Sdk.SharedKernel
{
    public abstract class AuditableEntity<TKey> : Entity<TKey>, IAuditableEntity<TKey>
    {
        public virtual DateTime CreatedAt { get; } = DateTime.Now;

        public virtual DateTime UpdatedAt { get; protected set; } = DateTime.Now;

        public virtual IEntity LastUpdater { get; protected set; }

        public virtual void Update<T>(IEntity<T> updater)
        {
            UpdatedAt = DateTime.Now;
            LastUpdater = updater;
            ExecuteUpdate(updater, UpdatedAt);
        }
    }
}