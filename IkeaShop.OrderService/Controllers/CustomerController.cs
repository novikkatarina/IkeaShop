
using IkeaShop.OrderService.Models;
using IkeaShop.OrderService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IkeaShop.CustomerService.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService CustomerService;

    public CustomerController(
        ICustomerService CustomerService,
        ILogger<CustomerController> logger)
    {
        this.CustomerService = CustomerService; ;
    }

    [HttpGet("{id}")]
    public IActionResult GetCustomer(Guid id)
    {
      var Customer = CustomerService.GetCustomerById(id);
        if (Customer == null)
        {
            return NotFound();
        }
        return Ok(Customer);
    }

    [HttpPost]
    public IActionResult CreateCustomer(Customer customer)
    {
        var createdCustomer = CustomerService.CreateCustomer(customer);
        return CreatedAtAction(nameof(GetCustomer), new { id = createdCustomer.Id }, createdCustomer);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCustomer(Guid id, Customer customer)
    {
        if (id != customer.Id)
        {
            return BadRequest();
        }
        var updatedCustomer = CustomerService.UpdateCustomer(customer);
        if (updatedCustomer == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(Guid id)
    {
        
        var deleted = CustomerService.DeleteCustomer(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }


}