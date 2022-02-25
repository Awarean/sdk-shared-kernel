namespace Awarean.Sdk.SharedKernel
{
    public interface IEntity
    {
    }

    public interface IEntity<out TKey> : IEntity
    {
        TKey Id { get; }

        event EntityUpdated OnUpdate;
    }
}