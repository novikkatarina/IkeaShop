namespace IkeaShop.Models;

/// <summary>
/// Represents a request to retrieve product names based on their identifiers.
/// </summary>
public class GetProductNamesRequest
{
  /// <summary>
  /// Gets or sets a collection of product identifiers.
  /// </summary>
  public IEnumerable<Guid> Ids { get; set; }
}