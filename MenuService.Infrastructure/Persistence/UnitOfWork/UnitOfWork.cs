using MenuService.Core.Entities;
using MenuService.Core.InterfacesRepositories;
using MenuService.Infrastructure.Persistence.Data;
using MenuService.Infrastructure.Persistence.Repositories;

namespace MenuService.Infrastructure.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly PizzaDbContext _context;

    public UnitOfWork(PizzaDbContext context, IPizzaRepository pizzaRepository)
    {
        _context = context;
        Pizzas = pizzaRepository;
    }

    public IPizzaRepository Pizzas { get; }

    public IGenericRepository<TEntity, TId> GetRepository<TEntity, TId>()
        where TEntity : BaseEntity<TId>
    {
        return new GenericRepository<TEntity, TId>(_context);
    }


    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}