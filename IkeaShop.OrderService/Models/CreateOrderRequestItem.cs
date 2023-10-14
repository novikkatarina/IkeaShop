namespace IkeaShop.OrderService.Models;

/// <summary>
/// Represents an item in a CreateOrderRequest, specifying product information and quantity.
/// </summary>
public class CreateOrderRequestItem
{
  /// <summary>
  /// Gets or sets the unique identifier of the product.
  /// </summary>
  public Guid ProductId { get; set; }

  /// <summary>
  /// Gets or sets the product number.
  /// </summary>
  public int ProductNumber { get; set; }

  /// <summary>
  /// Gets or sets the quantity of the product in the order.
  /// </summary>
  public int Quantity { get; set; }
}