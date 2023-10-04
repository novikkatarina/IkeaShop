namespace IkeaShop.OrderService.Models;

public class CreateOrderRequestItem
{
    public Guid ProductId { set; get; }
    public int ProductNumber { set; get; }
    public int Quantity { set; get; }
}