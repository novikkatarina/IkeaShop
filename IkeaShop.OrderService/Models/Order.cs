using IkeaShop.OrderService.Data;

namespace IkeaShop.OrderService.Models;

public class Order
{
    public Guid Id { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public DateTimeOffset EstimatedDeliveryDate { get; set; }
    public OrderStatus Status { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    public IEnumerable<OrderedItem> Items { get; set; }
    public decimal TotalPrice { get; set; }
    public Order()
    {
    }

    public Order(Guid customerId, IEnumerable<OrderedItem> items)
    {
        CustomerId = customerId;
        Items = items;
    }
}