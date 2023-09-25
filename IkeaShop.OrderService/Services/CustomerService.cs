using CommonDataAccess;
using IkeaShop.OrderService.Models;
using IkeaShop.OrderService.Services.Interfaces;

namespace IkeaShop.OrderService.Services;

public class CustomerService : ICustomerService
{
    private readonly IUnifiedRepository<Customer> CustomerRepository;

    public CustomerService(IUnifiedRepository<Customer> CustomerRepository)
    {
        this.CustomerRepository = CustomerRepository;
    }

    public Customer GetCustomerById(Guid id)
    {
        return CustomerRepository.GetById(id);
    }

    public Customer CreateCustomer(Customer Customer)
    {
        CustomerRepository.Add(Customer);
        return Customer;
    }

    public Customer UpdateCustomer(Customer Customer)
    {
        return CustomerRepository.Update(Customer);
    }

    public bool DeleteCustomer(Guid id)
    {
        var Customer = CustomerRepository.GetById(id);
        return CustomerRepository.Delete(Customer);
    }

    public List<Customer> GetAllCustomers()
    {
        return CustomerRepository.GetAll().ToList();
    }
}