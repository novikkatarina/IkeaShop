using IkeaShop.OrderService.Models;
using IkeaShop.OrderService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IkeaShop.OrderService.Controllers;

/// <summary>
/// API controller for managing orders.
/// </summary>
[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
  private readonly IOrderService orderService;

  /// <summary>
  /// Initializes a new instance of the <see cref="OrderController"/> class.
  /// </summary>
  /// <param name="orderService">The service for managing orders.</param>
  public OrderController(IOrderService orderService)
  {
    this.orderService = orderService;
  }

  /// <summary>
  /// Retrieves an order by its unique identifier.
  /// </summary>
  /// <param name="id">The unique identifier of the order.</param>
  /// <returns>An <see cref="IActionResult"/> containing the order information or a NotFound response if the order is not found.</returns>
  [HttpGet("{id}")]
  public IActionResult GetOrder(Guid id)
  {
    var order = orderService.GetOrderById(id);
    if (order == null)
    {
      return NotFound();
    }

    return Ok(order);
  }

  /// <summary>
  /// Creates a new order.
  /// </summary>
  /// <param name="request">The request containing information to create the order.</param>
  /// <returns>
  /// An <see cref="IActionResult"/> containing the created order information and a Created response with the location of the newly created resource.
  /// </returns>
  [HttpPost("CreateOrder")]
  public async Task<IActionResult> CreateOrder(
    [FromBody] CreateOrderRequest request)
  {
    try
    {
      var order = await orderService.CreateOrder(request);
      var response = new CreateOrderResponse();
      response.OrderId = order.Id;
      string formattedDate = order.EstimatedDeliveryDate
        .ToUniversalTime()
        .AddHours(4) // Adding 4 hours for GMT+4
        .ToString("dd.MM.yyyy HH:mm 'GMT+4'");
      response.EstimatedDeliveryTime = formattedDate;

      response.Price = order.TotalPrice;
      return Ok(response);
    }
    catch (ArgumentException exception)
    {
      return BadRequest(exception.Message);
    }
  }

  /// <summary>
  /// Updates an existing order.
  /// </summary>
  /// <param name="id">The unique identifier of the order to update.</param>
  /// <param name="order">The updated order information.</param>
  /// <returns>
  /// An <see cref="IActionResult"/> with a NoContent response if the update is successful, BadRequest if the provided ID does not match the order's ID, or NotFound if the order is not found.
  /// </returns>
  [HttpPut("{id}")]
  public IActionResult UpdateOrder(Guid id, Order order)
  {
    if (id != order.Id)
    {
      return BadRequest();
    }

    var updatedOrder = orderService.UpdateOrder(order);
    if (updatedOrder == null)
    {
      return NotFound();
    }

    return Ok(order);
  }

  /// <summary>
  /// Deletes an order by its unique identifier.
  /// </summary>
  /// <param name="id">The unique identifier of the order to delete.</param>
  /// <returns>
  /// An <see cref="IActionResult"/> with a NoContent response if the deletion is successful, or NotFound if the order is not found.
  /// </returns>
  [HttpDelete("{id}")]
  public IActionResult DeleteOrder(Guid id)
  {
    var deleted = orderService.DeleteOrder(id);
    if (!deleted)
    {
      return NotFound();
    }

    return Ok();
  }

  /// <summary>
  /// Marks an order as paid.
  /// </summary>
  /// <param name="request">The request containing the order ID to mark as paid.</param>
  /// <returns>
  /// An <see cref="IActionResult"/> with a NoContent response if the payment is successful, or NotFound if the order is not found.
  /// </returns>
  [HttpPost("pay")]
  public IActionResult Pay(PayRequest request)
  {
    var status = orderService.SetOrderPayed(request.OrderId);
    if (status == null)
    {
      return NotFound();
    }

    return Ok();
  }
}
