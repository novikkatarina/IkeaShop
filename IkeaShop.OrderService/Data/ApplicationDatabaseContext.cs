using IkeaShop.Order.Models;
using Microsoft.EntityFrameworkCore;
namespace IkeaShop.Order.Data;

public class ApplicationDatabaseContext : DbContext
{
        /// <summary>
        /// Order в БД.
        /// </summary>
        public DbSet<Models.Order> Orders { get; set; }
  
        /// <summary>
        /// Item в БД.
        /// </summary>
        public DbSet<Item> Items { get; set; }
  
        /// <summary>
        /// Customer в БД.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

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
                        "Host=localhost;Port=5432;Database=testdb;Username=postgres;Password=8313");
        }

        
}