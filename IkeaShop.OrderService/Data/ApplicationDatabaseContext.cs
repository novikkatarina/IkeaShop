using IkeaShop.OrderService.Models;
using Microsoft.EntityFrameworkCore;
namespace IkeaShop.OrderService.Data;

public class ApplicationDatabaseContext : DbContext
{
        /// <summary>
        /// Order в БД.
        /// </summary>
        public DbSet<Order> Orders { get; set; }
  
        /// <summary>
        /// Item в БД.
        /// </summary>
        public DbSet<OrderedItem> Items { get; set; }
  
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
                        "Host=localhost;Port=5432;Database=servicedb;Username=postgres;Password=8313");
        }

        
}