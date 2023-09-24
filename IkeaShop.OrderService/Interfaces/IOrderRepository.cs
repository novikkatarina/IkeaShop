using IkeaShop.Order.Data;

namespace IkeaShop.Order.Interfaces;

public interface IOrderRepository
{
    Models.Order GetOrderById(int id);
    bool AddOrder(Models.Order order);
    Models.Order UpdateOrder(Models.Order order);
    bool DeleteOrder(int oderId);
    IEnumerable<Models.Order> GetAllOrders();
}