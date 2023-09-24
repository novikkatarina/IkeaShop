using Microsoft.AspNetCore.Mvc;

namespace IkeaShop.Order.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> logger;

    public OrderController(
        
        ILogger<OrderController> logger)
    {
        this.logger = logger;
    }

    [HttpGet]
    public OrderResponse Get()
    {
        return new OrderResponse();
    }
    
    // httpget - returns all orders
    // httpost - creates order
    // httpput - updates order
    // httpdelete - delete order

    
    // service 
    
    
}