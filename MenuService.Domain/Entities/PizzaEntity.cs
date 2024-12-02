namespace MenuService.Domain.Entities;

public class PizzaEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<string> Ingredients { get; set; } = new();
    public decimal Price { get; set; }
}