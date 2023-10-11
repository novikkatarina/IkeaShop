using IkeaShop.OrderService.Models;
using IkeaShop.OrderService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IkeaShop.OrderService.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
  private readonly IOrderService orderService;

  public OrderController(
    IOrderService orderService
)
  {
    this.orderService = orderService;
  }

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

  [HttpPost("CreateOrder")]
  public async Task<IActionResult> CreateOrder(
    [FromBody] CreateOrderRequest request)
  {
    try
    {
      var order = await this.orderService.CreateOrder(request);
      var response = new CreateOrderResponse();
      response.OrderId = order.Id;
      response.EstimatedDeliveryTime = order.EstimatedDeliveryDate;
      response.Price = order.TotalPrice;
      return Ok(response);
    }
    catch (ArgumentException exception)
    {
      return BadRequest(exception.Message);
    }
  }

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
