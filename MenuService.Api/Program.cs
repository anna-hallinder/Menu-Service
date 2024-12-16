using Polly;
using MenuService.Application.InterfacesServices;
using MenuService.Application.Services;
using MenuService.Core.InterfacesRepositories;
using MenuService.Infrastructure.Persistence.Data;
using MenuService.Infrastructure.Persistence.Repositories;
using MenuService.Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);


// Lägg till SQLServer
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

// Retry-logik för databasanslutning
// 30 försök med 5 sekunder mellan
var policy = Policy.Handle<SqlException>()
.WaitAndRetryAsync(30, attempt => TimeSpan.FromSeconds(5),
(exception, timeSpan, retryCount, context) =>
{
    Console.WriteLine($"Retry {retryCount} failed, waiting {timeSpan.TotalSeconds} seconds.");
});

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PizzaDbContext>();
    try
    {
        await policy.ExecuteAsync(async () =>
        {
            await dbContext.Database.MigrateAsync();
            Console.WriteLine("Database connection succeeded and migration done.");
        });
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Could not connect to database {ex.Message}");
        throw;
    }
}


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();