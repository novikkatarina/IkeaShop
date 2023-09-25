using IkeaShop.OrderService.Data;

namespace IkeaShop.OrderService.Models;

public class Order
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime EstimatedDeliveryDate { get; set; }
    public OrderStatus Status { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    public IEnumerable<OrderedItem> Items { get; set; }
    public Order()
    {
    }

    public Order(Guid id, Guid customerId, IEnumerable<OrderedItem> items)
    {
        this.Id = id;
        CustomerId = customerId;
        Items = items;
    }
}