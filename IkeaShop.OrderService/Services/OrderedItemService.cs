using CommonDataAccess;
using IkeaShop.ItemService.Services.Interfaces;
using IkeaShop.OrderService.Data;
using IkeaShop.OrderService.Models;

namespace IkeaShop.ItemService.Services;

public class OrderedItemService : IOrderedItemService
{
    private readonly IUnifiedRepository<OrderedItem> ItemRepository;

    public OrderedItemService(IUnifiedRepository<OrderedItem> ItemRepository)
    {
        this.ItemRepository = ItemRepository;
    }

    public OrderedItem GetItemById(Guid id)
    {
        return ItemRepository.GetById(id);
    }

    public OrderedItem CreateItem(OrderedItem orderedItem)
    {
        ItemRepository.Add(orderedItem);
        return orderedItem;
    }

    public OrderedItem UpdateItem(OrderedItem orderedItem)
    {
        return ItemRepository.Update(orderedItem);
    }

    public bool DeleteItem(Guid id)
    {
        var Item = ItemRepository.GetById(id);
        return ItemRepository.Delete(Item);
    }

    // public IEnumerable<Item> GetItemsPrice(ItemRoom room)
    // {
    //     return ItemRepository.GetAll().ToList().Where(item => item.Room == room);
    // }

    public List<OrderedItem> GetAllItems()
    {
        return ItemRepository.GetAll().ToList();
    }

}