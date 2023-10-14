namespace IkeaShop.OrderService.Models;

/// <summary>
/// Represents a response containing information about a newly created order.
/// </summary>
public class CreateOrderResponse
{
  /// <summary>
  /// Gets or sets the unique identifier of the created order.
  /// </summary>
  public Guid OrderId { get; set; }

  /// <summary>
  /// Gets or sets the estimated delivery time for the order.
  /// </summary>
  public string EstimatedDeliveryTime { get; set; }

  /// <summary>
  /// Gets or sets the total price of the order.
  /// </summary>
  public decimal Price { get; set; }
}