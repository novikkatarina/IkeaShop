using IkeaShop.Models;
using Microsoft.EntityFrameworkCore;

namespace IkeaShop.Data;

public class ApplicationDatabaseContext  : DbContext
{
    /// <summary>
    /// Item в БД.
    /// </summary>
    public DbSet<Product> Products { get; set; }

    /// <summary>
    /// Базовый конструктор для настройки БД.
    /// </summary>
    /// <param name="options"></param>
    public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options) { }
    /// <summary>
    /// Задает опции для подключения к базе данных, где вызывается метод UseNpgsql(), в который передается строка подключения.
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=dbstorage;Username=postgres;Password=8313");
    }
}