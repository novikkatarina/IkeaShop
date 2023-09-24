using IkeaShop.Order.Data;

namespace IkeaShop.Order.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime EstimatedDeliveryDate { get; set; }
    public DateTime DeleteDate { get; set; }
    public EnumOrderStatus Status { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
}