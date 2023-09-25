using IkeaShop.OrderService.Models;
using IkeaShop.OrderService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IkeaShop.OrderService.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService orderService;
    private readonly ILogger<OrderController> logger;

    public OrderController(
        IOrderService orderService,
        ILogger<OrderController> logger)
    {
        this.orderService = orderService;
        this.logger = logger;
    }

    [HttpGet("{id}")]
    public IActionResult GetOrder(Guid id)
    {
        logger.LogInformation("я сюда зашел");
        var order = orderService.GetOrderById(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [HttpPost]
    public IActionResult CreateOrder([FromBody] Order order)
    {
        var createdOrder = orderService.CreateOrder(order);
        return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.Id }, createdOrder);
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
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOrder(Guid id)
    {
        
        var deleted = orderService.DeleteOrder(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
    
    // GetOrdersByDate
    
    
}