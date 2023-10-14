namespace IkeaShop.OrderService.Models;

/// <summary>
/// Represents a customer with associated information.
/// </summary>
public class Customer
{
  /// <summary>
  /// Gets or sets the unique identifier of the customer.
  /// </summary>
  public Guid Id { get; set; }

  /// <summary>
  /// Gets or sets the phone number of the customer.
  /// </summary>
  public string PhoneNumber { get; set; }

  /// <summary>
  /// Gets or sets the name of the customer.
  /// </summary>
  public string Name { get; set; }

  /// <summary>
  /// Gets or sets the address of the customer.
  /// </summary>
  public string Address { get; set; }

  /// <summary>
  /// Gets or sets the email address of the customer.
  /// </summary>
  public string Email { get; set; }
}