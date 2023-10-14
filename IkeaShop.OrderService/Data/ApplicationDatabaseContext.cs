using IkeaShop.OrderService.Models;
using Microsoft.EntityFrameworkCore;

namespace IkeaShop.OrderService.Data;

/// <summary>
/// Represents the database context for the IkeaShop application.
/// </summary>
public class ApplicationDatabaseContext : DbContext
{
  /// <summary>
  /// Gets or sets the DbSet for orders in the database.
  /// </summary>
  public DbSet<Order> Orders { get; set; }

  /// <summary>
  /// Gets or sets the DbSet for ordered items in the database.
  /// </summary>
  public DbSet<OrderedItem> Items { get; set; }

  /// <summary>
  /// Gets or sets the DbSet for customers in the database.
  /// </summary>
  public DbSet<Customer> Customers { get; set; }

  /// <summary>
  /// Initializes a new instance of the <see cref="ApplicationDatabaseContext"/> class with the specified options.
  /// </summary>
  /// <param name="options">The DbContext options.</param>
  public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options) { }

  /// <summary>
  /// Configures the DbContext options for connecting to the database.
  /// </summary>
  /// <param name="optionsBuilder">The options builder for configuring the database connection.</param>
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql(
      "Host=localhost;Port=5432;Database=servicedb;Username=postgres;Password=8313");
  }
}