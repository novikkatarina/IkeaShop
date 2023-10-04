using IkeaShop.OrderService.Models;

namespace IkeaShop.OrderService.Services.Interfaces;

public interface ICustomerService
{
    Customer GetCustomerById(Guid id);
    Customer CreateCustomer(Customer customer);
    Customer UpdateCustomer(Customer customer);
    bool DeleteCustomer(Guid id);
    List<Customer> GetAllCustomers();
}