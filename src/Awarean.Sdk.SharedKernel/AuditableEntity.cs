using Awarean.Sdk.SharedKernel;
using Awarean.Sdk.SharedKernel.Events;

namespace Awaren.Sdk.SharedKernel
{
    public abstract class AuditableEntity<TKey> : Entity<TKey>, IAuditableEntity<TKey>
    {
        public virtual DateTime CreatedAt { get; init; } = DateTime.Now;

        public virtual DateTime UpdatedAt { get; protected set; } = DateTime.Now;

        public virtual string UpdatedBy { get; protected set; }

        protected virtual void Update(string updatedBy)
        {
            UpdatedAt = DateTime.Now;
            UpdatedBy = updatedBy;
            ExecuteUpdate(updatedBy, UpdatedAt);
        }
    }
}