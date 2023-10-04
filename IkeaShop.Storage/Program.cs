using CommonDataAccess;
using CommonDataAccess.Repositories;
using IkeaShop.Data;
using IkeaShop.Models;
using IkeaShop.Models.Services;
using IkeaShop.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

// // Добавление сервисов в контекст ASP NET

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUnifiedRepository<Product>>(provider =>
{
    var dbContext = provider.GetRequiredService<ApplicationDatabaseContext>();
    return new UnifiedRepository<Product>(dbContext);
});

// Инициализация бд
builder.Services.AddDbContext<ApplicationDatabaseContext>(options =>
{
    // Подключение к бд находится в appsettings.json
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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