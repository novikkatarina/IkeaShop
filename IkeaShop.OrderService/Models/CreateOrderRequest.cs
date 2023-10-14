namespace IkeaShop.OrderService.Models;

/// <summary>
/// Represents a request for creating a new order, including customer and item information.
/// </summary>
public class CreateOrderRequest
{
  /// <summary>
  /// Gets or sets the customer information for the new order.
  /// </summary>
  public CustomerRequest Customer { get; set; }

  /// <summary>
  /// Gets or sets the collection of items to be included in the new order.
  /// </summary>
  public IEnumerable<CreateOrderRequestItem> Items { get; set; }
}