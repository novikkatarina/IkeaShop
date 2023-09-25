using IkeaShop.OrderService.Models;

namespace IkeaShop.OrderService.Services.Interfaces;

public interface ICustomerService
{
    Customer GetCustomerById(Guid id);
    Customer CreateCustomer(Customer Customer);
    Customer UpdateCustomer(Customer Customer);
    bool DeleteCustomer(Guid id);
    List<Customer> GetAllCustomers();
}