using IkeaShop.OrderService.Models;
using IkeaShop.OrderService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IkeaShop.OrderService.Controllers;

/// <summary>
/// API controller for managing customer information.
/// </summary>
[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
  private readonly ICustomerService CustomerService;

  /// <summary>
  /// Initializes a new instance of the <see cref="CustomerController"/> class.
  /// </summary>
  /// <param name="customerService">The service for managing customer information.</param>
  /// <param name="logger">The logger for logging controller actions.</param>
  public CustomerController(ICustomerService customerService,
    ILogger<CustomerController> logger)
  {
    this.CustomerService = customerService;
    // TODO: Initialize logger as needed.
  }

  /// <summary>
  /// Retrieves customer information by their unique identifier.
  /// </summary>
  /// <param name="id">The unique identifier of the customer.</param>
  /// <returns>An <see cref="IActionResult"/> containing the customer information or a NotFound response if the customer is not found.</returns>
  [HttpGet("{id}")]
  public IActionResult GetCustomer(Guid id)
  {
    var customer = CustomerService.GetCustomerById(id);
    if (customer == null)
    {
      return NotFound();
    }

    return Ok(customer);
  }

  /// <summary>
  /// Creates a new customer.
  /// </summary>
  /// <param name="customer">The customer information to create.</param>
  /// <returns>An <see cref="IActionResult"/> containing the created customer information and a Created response with the location of the newly created resource.</returns>
  [HttpPost]
  public IActionResult CreateCustomer(Customer customer)
  {
    var createdCustomer = CustomerService.CreateCustomer(customer);
    return CreatedAtAction(nameof(GetCustomer), new { id = createdCustomer.Id },
      createdCustomer);
  }

  /// <summary>
  /// Updates an existing customer's information.
  /// </summary>
  /// <param name="id">The unique identifier of the customer to update.</param>
  /// <param name="customer">The updated customer information.</param>
  /// <returns>An <see cref="IActionResult"/> with a NoContent response if the update is successful, BadRequest if the provided ID does not match the customer's ID, or NotFound if the customer is not found.</returns>
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

  /// <summary>
  /// Deletes a customer by their unique identifier.
  /// </summary>
  /// <param name="id">The unique identifier of the customer to delete.</param>
  /// <returns>An <see cref="IActionResult"/> with a NoContent response if the deletion is successful, or NotFound if the customer is not found.</returns>
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
