using IkeaShop.Data;

namespace IkeaShop.Models.Services;

public interface IProductService
{
    Product GetItemById(Guid id);
    Product CreateItem(Product product);
    Product UpdateItem(Product product);
    bool DeleteItem(Guid id);
    List<Product> GetAllItems();
    IEnumerable<Product>GetProductsByRoom(ProductRoom room);
    int GetProductCount(Guid id);
    
    decimal GetProductPrice (Guid id);
}