using Awarean.Sdk.SharedKernel.Delegates;

namespace Awarean.Sdk.SharedKernel;

public interface IQueryRepository<T, V> where T : IEntity<V>
{
    Task<T> GetByIdAsync(V id);
    Task<IEnumerable<T>> GetWhereAsync(GetWhereSelector<T> filter);
}