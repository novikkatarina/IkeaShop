using IkeaShop.Data;

namespace IkeaShop.Models;

public class Product
{
    public Guid Id { set; get; }
    public int ProductNumber { set; get; }
    public decimal Price { get; set; }
    public int Quantity { set; get; }
    public ProductRoom Room { set; get; }
    public string Title { set; get; }
    public string LinkFirst { set; get; }
    public string LinkSecond  { set; get; }
}