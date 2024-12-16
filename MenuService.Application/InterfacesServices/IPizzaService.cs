using MenuService.Core.Entities;

namespace MenuService.Application.InterfacesServices;

public interface IPizzaService : IGenericService<int, PizzaEntity>
{
    Task<PizzaEntity?> GetPizzaByNameAsync(string name);
}