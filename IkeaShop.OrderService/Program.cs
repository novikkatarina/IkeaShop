using CommonDataAccess;
using CommonDataAccess.Repositories;
using IkeaShop.ItemService.Services;
using IkeaShop.ItemService.Services.Interfaces;
using IkeaShop.OrderService.Data;
using IkeaShop.OrderService.Models;
using IkeaShop.OrderService.Services;
using IkeaShop.OrderService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
  options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

// // Добавление сервисов в контекст ASP NET

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUnifiedRepository<Order>>(provider =>
{
    var dbContext = provider.GetRequiredService<ApplicationDatabaseContext>();
    return new UnifiedRepository<Order>(dbContext);
});

builder.Services.AddScoped<IUnifiedRepository<Customer>>(provider =>
{
    var dbContext = provider.GetRequiredService<ApplicationDatabaseContext>();
    return new UnifiedRepository<Customer>(dbContext);
});

builder.Services.AddScoped<IOrderedItemService, OrderedItemService>();
builder.Services.AddScoped<IUnifiedRepository<OrderedItem>>(provider =>
{
    var dbContext = provider.GetRequiredService<ApplicationDatabaseContext>();
    return new UnifiedRepository<OrderedItem>(dbContext);
});

// Инициализация бд
builder.Services.AddDbContext<ApplicationDatabaseContext>(options =>
{
    // Подключение к бд находится в appsettings.json
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
ExampleSeed.SeedData(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Open"); // Apply the CORS policy here
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();