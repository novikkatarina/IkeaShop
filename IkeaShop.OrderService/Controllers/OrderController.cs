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
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
    {
      Order order = null;
      try
      {
        order = await this.orderService.CreateOrder(request);
      }
        catch (NullReferenceException)
        {
          return NotFound("Товара нет в наличии");
        }

        return Ok(order);
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

        [HttpDelete("changestatus/{order}")]
        public IActionResult ChangeOrderStatus(Order order)
        {
        
            var status = orderService.ChangeOrderStatus(order);
            if (status == null)
            {
                return NotFound();
            }
            return Ok();
        }
    
        
    }