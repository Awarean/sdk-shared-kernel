
namespace Awarean.Sdk.SharedKernel;

public interface ICommandRepository<T, V> where T : IEntity<V>
{
    Task<V> SaveAsync(T entity);
    Task UpdateAsync(V id, T updatedEntity);
    Task DeleteAsync(V id);
}