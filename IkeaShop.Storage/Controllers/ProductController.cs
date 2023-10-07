using IkeaShop.Data;
using IkeaShop.Models;
using IkeaShop.Models.Services;
using IkeaShop.Service;
using Microsoft.AspNetCore.Mvc;

namespace IkeaShop.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService ProductService;
    private readonly ILogger<ProductController> logger;

    public ProductController(
        IProductService ProductService,
        ILogger<ProductController> logger)
    {
        this.ProductService = ProductService;
        this.logger = logger;
    }

    [HttpGet("GetProducts")]
    public IActionResult GetProducts(Guid id)
    {
        var products = ProductService.GetAllItems();
        if (products == null)
        {
            return NotFound();
        }

        return Ok(products);
    }
    
    [HttpGet("count/{id}")]
    public IActionResult GetProductCount(Guid id)
    { 
        
        var count = ProductService.GetProductCount(id);
        if (count == null)
        {
            return NotFound();
        }
        return Ok(count);
    }

    [HttpGet("price/{id}")]
    public IActionResult GetProductPrice(Guid id)
    {
        
        var price = ProductService.GetProductPrice(id);
        if (price == null)
        {
            return NotFound();
        }

        return Ok(price);

    }

    
    [HttpGet("GetItemsByRoom/{room}")]
    public IActionResult GetProductsByRoom(ProductRoom room)
    {
        var found = ProductService.GetProductsByRoom(room);
        if (!found.Any())
        {
            return NotFound();
        }

        return Ok(found);
    }
    
}