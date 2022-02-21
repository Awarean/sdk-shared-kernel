using Awaren.Sdk.SharedKernel;

namespace Awarean.Sdk.SharedKernel.Events
{
    public record EntityUpdatedEventArgs(IEntity UpdatedBy, DateTime ChangeDate);
}