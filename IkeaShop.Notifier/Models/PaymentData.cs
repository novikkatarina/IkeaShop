namespace Notifier;

public class PaymentData
{
  public string Email { set; get; }
  public DateTimeOffset EstimatedDeliveryTime { set; get; }
  public decimal Price { set; get; }
  public string Name { set; get; }

}
