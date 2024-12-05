using MenuService.Application.InterfacesServices;
using MenuService.Application.Services;
using MenuService.Core.Entities;
using MenuService.Core.InterfacesRepositories;
using MenuService.Infrastructure.Persistence.Data;
using MenuService.Infrastructure.Persistence.Repositories;
using MenuService.Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Lägg till EF Core InMemory Database
builder.Services.AddDbContext<PizzaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();
builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();


//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<PizzaDbContext>();

//    // Lägg till exempeldata
//    dbContext.Pizzas.AddRange(
//        new PizzaEntity
//        {
//            Id = 1,
//            Name = "Margherita",
//            Price = 100,
//            Ingredients = new List<string> { "Tomato", "Cheese" } // Konvertera till lista
//        },
//        new PizzaEntity
//        {
//            Id = 2,
//            Name = "Pepperoni",
//            Price = 120,
//            Ingredients = new List<string> { "Tomato", "Cheese", "Pepperoni" } // Konvertera till lista
//        }
//    );

//    dbContext.SaveChanges();
//}





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
