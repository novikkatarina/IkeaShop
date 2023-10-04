using IkeaShop.OrderService.Data;

namespace IkeaShop.OrderService.Services.Interfaces;
using Models;
using System.Collections.Generic;

public interface IOrderService
{
    Order GetOrderById(Guid id);
    Task<Order> CreateOrder(CreateOrderRequest order);
    Order UpdateOrder(Order order);
    bool DeleteOrder(Guid id);
    List<Order> GetAllOrders();
    Task<int> GetQuantityAsync(Guid itemId);
    Order ChangeOrderStatus(Order order);
}
