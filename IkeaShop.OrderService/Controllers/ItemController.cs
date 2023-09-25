using IkeaShop.ItemService.Services.Interfaces;
using IkeaShop.OrderService.Data;
using IkeaShop.OrderService.Models;
using Microsoft.AspNetCore.Mvc;

namespace IkeaShop.itemService.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly IItemService ItemService;
    private readonly ILogger<ItemController> logger;

    public ItemController(
        IItemService itemService,
        ILogger<ItemController> logger)
    {
        this.ItemService = itemService;
        this.logger = logger;
    }

    [HttpGet("{id}")]
    public IActionResult Getitem(Guid id)
    {
        logger.LogInformation("я сюда зашел");
        var item = ItemService.GetItemById(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPost]
    public IActionResult Createitem(OrderedItem orderedItem)
    {
        var createditem = ItemService.CreateItem(orderedItem);
        return CreatedAtAction(nameof(Getitem), new { id = createditem.Id }, createditem);
    }

    [HttpPut("{id}")]
    public IActionResult Updateitem(Guid id, OrderedItem orderedItem)
    {
        if (id != orderedItem.Id)
        {
            return BadRequest();
        }
        var updateditem = ItemService.UpdateItem(orderedItem);
        if (updateditem == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Deleteitem(Guid id)
    {
        
        var deleted = ItemService.DeleteItem(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
    
    
    
    [HttpGet("GetItemsByRoom")]
    public IActionResult GetItemsByRoom(ItemRoom room)
    {

        var found = ItemService.GetItemsRoom(room);
        if (!found.Any())
        {
            return NotFound();
        }
        return NoContent();
    }
    
}