using IkeaShop.Order.Models;

namespace IkeaShop.Order.Interfaces;

public interface ICustomerRepository
{
    Customer GetCustomerById(int id);
    bool AddCustomer(Customer customer);
    Customer UpdateCustomer(Customer customer);
    bool DeleteCustomer(int customerId);
    IEnumerable<Customer> GetAllCustomers();
}