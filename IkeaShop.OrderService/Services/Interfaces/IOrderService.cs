namespace IkeaShop.OrderService.Services.Interfaces;
using Models;
using System.Collections.Generic;

public interface IOrderService
{
    Order GetOrderById(Guid id);
    Order CreateOrder(Order order);
    Order UpdateOrder(Order order);
    bool DeleteOrder(Guid id);
    List<Order> GetAllOrders();
}
