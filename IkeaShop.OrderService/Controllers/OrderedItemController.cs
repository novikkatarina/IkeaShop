using IkeaShop.ItemService.Services.Interfaces;
using IkeaShop.OrderService.Data;
using IkeaShop.OrderService.Models;
using Microsoft.AspNetCore.Mvc;

namespace IkeaShop.itemService.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderedItemController : ControllerBase
{
    private readonly IOrderedItemService _orderedItemService;
    private readonly ILogger<OrderedItemController> logger;

    public OrderedItemController(
        IOrderedItemService orderedItemService)
    {
        this._orderedItemService = orderedItemService;
    }

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

    [HttpPost]
    public IActionResult Createitem(OrderedItem orderedItem)
    {
        var createditem = _orderedItemService.CreateItem(orderedItem);
        return CreatedAtAction(nameof(Getitem), new { id = createditem.Id }, createditem);
    }

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