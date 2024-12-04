namespace MenuService.Core.Entities;

public class PizzaEntity : BaseEntity<int>
{

    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public List<string> Ingredients { get; set; } = new();
}