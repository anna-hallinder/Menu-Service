using MenuService.Application.InterfacesServices;
using MenuService.Core.Entities;
using MenuService.Infrastructure.Persistence.UnitOfWork;

namespace MenuService.Application.Services;

public class PizzaService : GenericService<PizzaEntity, int>, IPizzaService
{
    private readonly IUnitOfWork _unitOfWork;

    public PizzaService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PizzaEntity?> GetPizzaByNameAsync(string name)
    {
        return await _unitOfWork.Pizzas.GetPizzaByNameAsync(name);
    }
}
