namespace IkeaShop.OrderService.Models;

public class Customer
{
    public Guid Id { get; set; }
    public string PhoneNumber { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public IEnumerable<Order> Orders { get; set; }

    // public Customer()
    // {
    //     
    // }
    //
    // public Customer(Guid id, )
    // {
    //     
    // }
}