using MenuService.Core.Entities;

namespace MenuService.Core.InterfacesRepositories;

public interface IPizzaRepository : IGenericRepository<PizzaEntity, int>
{
    Task<PizzaEntity?> GetPizzaByNameAsync(string name);

}