using MenuService.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MenuService.Infrastructure.Persistence.Data;

public class PizzaDbContext : DbContext
{
    public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options)
    {
    }

    public DbSet<PizzaEntity> Pizzas { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PizzaEntity>().HasKey(p => p.Id);

        modelBuilder.Entity<PizzaEntity>()
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<PizzaEntity>()
            .Property(p => p.Ingredients)
            .IsRequired();

        modelBuilder.Entity<PizzaEntity>()
            .Property(p => p.Price)
            .IsRequired()
            .HasPrecision(10, 2);

        base.OnModelCreating(modelBuilder);
    }
}

