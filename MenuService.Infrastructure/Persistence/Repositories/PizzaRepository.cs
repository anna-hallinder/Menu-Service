using MenuService.Core.Entities;
using MenuService.Core.InterfacesRepositories;
using MenuService.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace MenuService.Infrastructure.Persistence.Repositories;

public class PizzaRepository : GenericRepository<PizzaEntity, int>, IPizzaRepository
{
    private readonly DbSet<PizzaEntity> _pizzas;

    public PizzaRepository(PizzaDbContext context) : base(context)
    {
        _pizzas = context.Set<PizzaEntity>();
    }

    public async Task<PizzaEntity?> GetPizzaByNameAsync(string name)
    {
        return await _pizzas.FirstOrDefaultAsync(p => p.Name == name);
    }
}
