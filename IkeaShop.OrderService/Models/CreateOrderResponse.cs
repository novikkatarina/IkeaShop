namespace IkeaShop.OrderService.Models;

public class CreateOrderResponse
{
  public Guid OrderId { get; set; }
  public string EstimatedDeliveryTime { get; set; }
  public decimal Price { get; set; }
}
