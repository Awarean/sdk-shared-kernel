
namespace Awarean.Sdk.SharedKernel.Repositories;

public interface ICommandRepository<T, V> where T : IEntity<V>
{
    Task SaveAsync(T entity);
    Task UpdateAsync(V id, T updatedEntity);
    Task DeleteAsync(V id);
}