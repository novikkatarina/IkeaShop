namespace IkeaShop.OrderService.Models;

public class CreateOrderRequest
{
    public Customer Customer { get; set; }
    public IEnumerable<CreateOrderRequestItem> Items { get; set; }
}