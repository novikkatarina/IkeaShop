using IkeaShop.Order.Models;

namespace IkeaShop.OrderService.Interfaces;

public interface IItemRepository
{
    Item GetItemById(int id);
    bool AddItem(Item item);
    Item UpdateItem(Item item);
    bool DeleteItem(int itemId);
    IEnumerable<Item> GetAllItems();
}