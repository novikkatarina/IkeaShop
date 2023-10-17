using IkeaShop.ItemService.Services.Interfaces;
using IkeaShop.OrderService.Models;
using Microsoft.AspNetCore.Mvc;

namespace IkeaShop.OrderService.Controllers;

/// <summary>
/// API controller for managing ordered items.
/// </summary>
[ApiController]
[Route("[controller]")]
public class OrderedItemController : ControllerBase
{
  private readonly IOrderedItemService _orderedItemService;
  private readonly ILogger<OrderedItemController> logger;

  /// <summary>
  /// Initializes a new instance of the <see cref="OrderedItemController"/> class.
  /// </summary>
  /// <param name="orderedItemService">The service for managing ordered items.</param>
  public OrderedItemController(IOrderedItemService orderedItemService)
  {
    this._orderedItemService = orderedItemService;
  }

  /// <summary>
  /// Retrieves an ordered item by its unique identifier.
  /// </summary>
  /// <param name="id">The unique identifier of the ordered item.</param>
  /// <returns>An <see cref="IActionResult"/> containing the ordered item information or a NotFound response if the item is not found.</returns>
  [HttpGet("{id}")]
  public IActionResult Getitem(Guid id)
  {
    var item = _orderedItemService.GetItemById(id);
    if (item == null)
    {
      return NotFound();
    }
    return Ok(item);
  }

  /// <summary>
  /// Updates an existing ordered item.
  /// </summary>
  /// <param name="id">The unique identifier of the ordered item to update.</param>
  /// <param name="orderedItem">The updated ordered item information.</param>
  /// <returns>
  /// An <see cref="IActionResult"/> with a NoContent response if the update is successful, BadRequest if the provided ID does not match the ordered item's ID, or NotFound if the item is not found.
  /// </returns>
  [HttpPut("{id}")]
  public IActionResult Updateitem(Guid id, OrderedItem orderedItem)
  {
    if (id != orderedItem.Id)
    {
      return BadRequest();
    }
    var updateditem = _orderedItemService.UpdateItem(orderedItem);
    if (updateditem == null)
    {
      return NotFound();
    }
    return NoContent();
  }

  /// <summary>
  /// Deletes an ordered item by its unique identifier.
  /// </summary>
  /// <param name="id">The unique identifier of the ordered item to delete.</param>
  /// <returns>
  /// An <see cref="IActionResult"/> with a NoContent response if the deletion is successful, or NotFound if the item is not found.
  /// </returns>
  [HttpDelete("{id}")]
  public IActionResult Deleteitem(Guid id)
  {
    var deleted = _orderedItemService.DeleteItem(id);
    if (!deleted)
    {
      return NotFound();
    }
    return NoContent();
  }
}