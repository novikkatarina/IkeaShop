using IkeaShop.Models;
using Microsoft.EntityFrameworkCore;

namespace IkeaShop.Data
{
  /// <summary>
  /// Represents the application's database context for interacting with the database.
  /// </summary>
  public class ApplicationDatabaseContext : DbContext
  {
    /// <summary>
    /// Gets or sets the DbSet for managing products in the database.
    /// </summary>
    public DbSet<Product> Products { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationDatabaseContext"/> class.
    /// </summary>
    /// <param name="options">The DbContextOptions to configure the database context.</param>
    public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options) { }

    /// <summary>
    /// Configures the database connection using Npgsql with connection details.
    /// </summary>
    /// <param name="optionsBuilder">The options builder for configuring the database connection.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseNpgsql(
        "Host=localhost;Port=5432;Database=dbstorage;Username=postgres;Password=8313");
    }
  }
}
