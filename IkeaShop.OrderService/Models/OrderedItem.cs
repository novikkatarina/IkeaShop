using IkeaShop.OrderService.Data;

namespace IkeaShop.OrderService.Models;

public class OrderedItem
{
    public Guid Id { set; get; }
    public Guid ProductId { get; set; }
    public int ProductNumber { set; get; }
    public decimal Price { get; set; }
    public int Quantity { set; get; }
    public Guid OrderId { set; get; }
    public Order Order { get; set; }
}