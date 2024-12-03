using MenuService.Core.Entities;

namespace MenuService.Core.InterfacesRepositories;

public interface IGenericRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(TId id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TId id);
}
