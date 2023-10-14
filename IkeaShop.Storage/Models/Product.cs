using IkeaShop.Data;

namespace IkeaShop.Models;

/// <summary>
/// Represents a product in the IkeaShop application.
/// </summary>
public class Product
{
  /// <summary>
  /// Gets or sets the unique identifier of the product.
  /// </summary>
  public Guid Id { set; get; }

  /// <summary>
  /// Gets or sets the product number.
  /// </summary>
  public int ProductNumber { set; get; }

  /// <summary>
  /// Gets or sets the price of the product.
  /// </summary>
  public decimal Price { get; set; }

  /// <summary>
  /// Gets or sets the quantity of the product available.
  /// </summary>
  public int Quantity { set; get; }

  /// <summary>
  /// Gets or sets the room where the product is intended for use.
  /// </summary>
  public ProductRoom Room { set; get; }

  /// <summary>
  /// Gets or sets the title or name of the product.
  /// </summary>
  public string Title { set; get; }

  /// <summary>
  /// Gets or sets the link to the first image of the product.
  /// </summary>
  public string LinkFirst { set; get; }

  /// <summary>
  /// Gets or sets the link to the second image of the product.
  /// </summary>
  public string LinkSecond { set; get; }

  /// <summary>
  /// Gets or sets the description of the product.
  /// </summary>
  public string Description { set; get; }
}
