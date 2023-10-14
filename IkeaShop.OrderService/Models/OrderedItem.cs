namespace IkeaShop.OrderService.Models;

/// <summary>
/// Represents an ordered item with associated product information.
/// </summary>
public class OrderedItem
{
  /// <summary>
  /// Gets or sets the unique identifier of the ordered item.
  /// </summary>
  public Guid Id { get; set; }

  /// <summary>
  /// Gets or sets the unique identifier of the product associated with the ordered item.
  /// </summary>
  public Guid ProductId { get; set; }

  /// <summary>
  /// Gets or sets the product number of the ordered item.
  /// </summary>
  public int ProductNumber { get; set; }

  /// <summary>
  /// Gets or sets the price of the ordered item.
  /// </summary>
  public decimal Price { get; set; }

  /// <summary>
  /// Gets or sets the quantity of the ordered item.
  /// </summary>
  public int Quantity { get; set; }

  /// <summary>
  /// Gets or sets the unique identifier of the order associated with the item.
  /// </summary>
  public Guid OrderId { get; set; }

  /// <summary>
  /// Gets or sets the order associated with the item.
  /// </summary>
  public Order Order { get; set; }
}