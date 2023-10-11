using IkeaShop.Data;
using IkeaShop.Models;

namespace IkeaShop.Service;

public interface IProductService
{
  Product GetItemById(Guid id);
  Product CreateItem(Product product);
  Product UpdateItem(Product product);
  bool DeleteItem(Guid id);
  List<Product> GetAllItems();
  IEnumerable<Product> GetProductsByRoom(ProductRoom room);
  int GetProductCount(Guid id);
  decimal GetProductPrice(Guid id);
  IEnumerable<string> GetProductNames(IEnumerable<Guid> id);
}
