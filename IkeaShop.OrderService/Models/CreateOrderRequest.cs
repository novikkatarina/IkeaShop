namespace IkeaShop.OrderService.Models;

public class CreateOrderRequest
{
    public CustomerRequest Customer { get; set; }
    public IEnumerable<CreateOrderRequestItem> Items { get; set; }
}