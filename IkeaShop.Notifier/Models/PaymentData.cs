namespace Notifier.Models;

/// <summary>
/// Represents payment and customer information for sending email notifications.
/// </summary>
public class PaymentData
{
  /// <summary>
  /// Gets or sets the email address of the recipient.
  /// </summary>
  public string Email { get; set; }

  /// <summary>
  /// Gets or sets the estimated delivery time of the order.
  /// </summary>
  public DateTimeOffset EstimatedDeliveryTime { get; set; }

  /// <summary>
  /// Gets or sets the total price of the order.
  /// </summary>
  public decimal Price { get; set; }

  /// <summary>
  /// Gets or sets the name of the customer.
  /// </summary>
  public string Name { get; set; }
}