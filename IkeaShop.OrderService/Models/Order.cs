using IkeaShop.OrderService.Data;

namespace IkeaShop.OrderService.Models;

/// <summary>
/// Represents an order with associated information.
/// </summary>
public class Order
{
  /// <summary>
  /// Gets or sets the unique identifier of the order.
  /// </summary>
  public Guid Id { get; set; }

  /// <summary>
  /// Gets or sets the date and time when the order was placed.
  /// </summary>
  public DateTimeOffset OrderDate { get; set; }

  /// <summary>
  /// Gets or sets the estimated delivery date and time for the order.
  /// </summary>
  public DateTimeOffset EstimatedDeliveryDate { get; set; }

  /// <summary>
  /// Gets or sets the status of the order.
  /// </summary>
  public OrderStatus Status { get; set; }

  /// <summary>
  /// Gets or sets the unique identifier of the customer associated with the order.
  /// </summary>
  public Guid CustomerId { get; set; }

  /// <summary>
  /// Gets or sets the customer associated with the order.
  /// </summary>
  public Customer Customer { get; set; }

  /// <summary>
  /// Gets or sets the collection of ordered items in the order.
  /// </summary>
  public IEnumerable<OrderedItem> Items { get; set; }

  /// <summary>
  /// Gets or sets the total price of the order.
  /// </summary>
  public decimal TotalPrice { get; set; }

  /// <summary>
  /// Initializes a new instance of the <see cref="Order"/> class.
  /// </summary>
  public Order()
  {
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="Order"/> class with specified customer and items.
  /// </summary>
  /// <param name="customerId">The unique identifier of the customer associated with the order.</param>
  /// <param name="items">The collection of ordered items in the order.</param>
  public Order(Guid customerId, IEnumerable<OrderedItem> items)
  {
    CustomerId = customerId;
    Items = items;
  }
}