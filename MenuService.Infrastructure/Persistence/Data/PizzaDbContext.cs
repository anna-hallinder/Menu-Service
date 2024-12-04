using MenuService.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MenuService.Infrastructure.Persistence.Data;

public class PizzaDbContext : DbContext
{
    public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options)
    {
    }

    public DbSet<PizzaEntity> Pizzas { get; set; } = null!;

}