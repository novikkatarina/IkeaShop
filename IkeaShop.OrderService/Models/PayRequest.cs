namespace IkeaShop.OrderService.Models;

/// <summary>
/// Represents a payment request specifying the unique identifier of an order to be paid.
/// </summary>
public class PayRequest
{
  /// <summary>
  /// Gets or sets the unique identifier of the order to be paid.
  /// </summary>
  public Guid OrderId { get; set; }
}