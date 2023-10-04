using IkeaShop.OrderService.Data;
using IkeaShop.OrderService.Models;

namespace IkeaShop.ItemService.Services.Interfaces;
using System.Collections.Generic;

public interface IOrderedItemService
{
    OrderedItem GetItemById(Guid id);
    OrderedItem CreateItem(OrderedItem orderedItem);
    OrderedItem UpdateItem(OrderedItem orderedItem);
    bool DeleteItem(Guid id);
    List<OrderedItem> GetAllItems();
}