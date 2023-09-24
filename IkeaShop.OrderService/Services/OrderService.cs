using IkeaShop.Order.Data;

namespace IkeaShop.Order.Services;

public class OrderService
{
    private readonly ApplicationDatabaseContext context;

    public OrderService(ApplicationDatabaseContext context)
    {
        this.context = context;
    }
    

    // public IEnumerable<Service.Order> GetOrders()
    // {
    //     return Order;
    // }
}