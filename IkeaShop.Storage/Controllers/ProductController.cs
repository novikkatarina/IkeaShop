using IkeaShop.Data;
using IkeaShop.Models;
using IkeaShop.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace IkeaShop.Controllers;

/// <summary>
/// Controller for managing product-related actions.
/// </summary>
[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
  private readonly IProductService ProductService;
  private readonly ILogger<ProductController> logger;

  /// <summary>
  /// Initializes a new instance of the <see cref="ProductController"/> class.
  /// </summary>
  /// <param name="productService">The product service.</param>
  /// <param name="logger">The logger.</param>
  public ProductController(
    IProductService productService,
    ILogger<ProductController> logger)
  {
    this.ProductService = productService;
    this.logger = logger;
  }

  /// <summary>
  /// Gets all products.
  /// </summary>
  /// <param name="id">The unique identifier of the product.</param>
  /// <returns>A list of all products.</returns>
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

  /// <summary>
  /// Gets the count of a specific product.
  /// </summary>
  /// <param name="id">The unique identifier of the product.</param>
  /// <returns>The count of the product.</returns>
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

  /// <summary>
  /// Gets the price of a specific product.
  /// </summary>
  /// <param name="id">The unique identifier of the product.</param>
  /// <returns>The price of the product.</returns>
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

  /// <summary>
  /// Gets products by room.
  /// </summary>
  /// <param name="room">The room for which to retrieve products.</param>
  /// <returns>A list of products for the specified room.</returns>
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

  /// <summary>
  /// Gets product names by their identifiers.
  /// </summary>
  /// <param name="request">The request containing product identifiers.</param>
  /// <returns>A list of product names corresponding to the provided identifiers.</returns>
  [HttpPost("GetProductNames")]
  public IActionResult GetProductById([FromBody] GetProductNamesRequest request)
  {
    var productToFind = ProductService.GetProductNames(request.Ids);
    return Ok(productToFind);
  }

  [HttpPost("ReduceQuantityProduct")]
  public IActionResult ReduceQuantityProduct([FromBody] List<ProductToReduce> productsToReduce)
  {
    var quantity = ProductService.ReduceQuantityProduct(productsToReduce);
  {if (quantity != null)
    return Ok();
  }
  return NotFound();
  }
}
