namespace IkeaShop.Order.Models;

public class Item
{
    public int Id { set; get; }
    public int ProductNumber { set; get; }
    public decimal Price { get; set; }
    public int Quantity { set; get; }
    public Guid OrderId { set; get; }
    public Order Order { get; set; }
}