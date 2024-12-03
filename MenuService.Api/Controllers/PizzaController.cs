using MenuService.Application.InterfacesServices;
using MenuService.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MenuService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzasController : ControllerBase
{
    private readonly IPizzaService _pizzaService;

    public PizzasController(IPizzaService pizzaService)
    {
        _pizzaService = pizzaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pizzas = await _pizzaService.GetAllAsync();
        return Ok(pizzas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var pizza = await _pizzaService.GetByIdAsync(id);
        if (pizza == null)
        {
            return NotFound();
        }
        return Ok(pizza);
    }

    [HttpPost]
    public async Task<IActionResult> Add(PizzaEntity pizza)
    {
        var createdPizza = await _pizzaService.AddAsync(pizza);
        return CreatedAtAction(nameof(GetById), new { id = createdPizza.Id }, createdPizza);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, PizzaEntity pizza)
    {
        if (id != pizza.Id)
        {
            return BadRequest();
        }
        var updatedPizza = await _pizzaService.UpdateAsync(pizza);
        return Ok(updatedPizza);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deletedPizza = await _pizzaService.DeleteAsync(id);
        if (deletedPizza == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet("name/{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var pizza = await _pizzaService.GetPizzaByNameAsync(name);
        if (pizza == null)
        {
            return NotFound();
        }
        return Ok(pizza);
    }
}