namespace IkeaShop.Models;

public class GetProductNamesRequest
{
  public IEnumerable<Guid> Ids { get; set; }
}
