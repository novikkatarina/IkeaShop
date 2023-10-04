using CommonDataAccess;
using IkeaShop.Data;
using IkeaShop.Models;
using IkeaShop.Models.Services;

namespace IkeaShop.Service;

public class ProductService : IProductService
{
    private readonly IUnifiedRepository<Product> ItemRepository;


    public ProductService(IUnifiedRepository<Product> itemRepository)
    {
        this.ItemRepository = itemRepository;
    }

    public Product GetItemById(Guid id)
    {
        return ItemRepository.GetById(id);
    }

    public Product CreateItem(Product product)
    {
        ItemRepository.Add(product);
        return product;
    }

    public Product UpdateItem(Product product)
    {
        return ItemRepository.Update(product);
    }

    public bool DeleteItem(Guid id)
    {
        var Item = ItemRepository.GetById(id);
        return ItemRepository.Delete(Item);
    }

    public List<Product> GetAllItems()
    {
        return ItemRepository.GetAll().ToList();
    }

    public IEnumerable<Product> GetProductsByRoom(ProductRoom room)
    {
        var productsByRoom = ItemRepository.GetAll().Where(x => x.Room == room);
        return productsByRoom;
    }

    public int GetProductCount(Guid id)
    {
        var count = GetItemById(id).Quantity;
        return count;
    }

    public decimal GetProductPrice(Guid id)
    {
        var count = GetItemById(id).Price;
        return count;
    }
}