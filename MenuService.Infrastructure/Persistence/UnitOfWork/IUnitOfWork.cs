using MenuService.Core.Entities;
using MenuService.Core.InterfacesRepositories;

namespace MenuService.Infrastructure.Persistence.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IPizzaRepository Pizzas { get; }
    IGenericRepository<TEntity, TId> GetRepository<TEntity, TId>() where TEntity : BaseEntity<TId>;
    Task<int> CompleteAsync();
}
