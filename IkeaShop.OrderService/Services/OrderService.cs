using System.Text;
using CommonDataAccess;
using IkeaShop.OrderService.Data;
using IkeaShop.OrderService.Services.Interfaces;
using IkeaShop.OrderService.Models;
using Newtonsoft.Json;

namespace IkeaShop.OrderService.Services;

using System.Collections.Generic;
using System.Linq;

public class OrderService : IOrderService
{
  private readonly IUnifiedRepository<OrderedItem> orderedItemRepository;
  private readonly IUnifiedRepository<Customer> customerRepository;
  private readonly IUnifiedRepository<Order> orderRepository;
  private readonly HttpClient httpClient;

  public OrderService(
    IUnifiedRepository<OrderedItem> orderedItemRepository,
    IUnifiedRepository<Customer> customerRepository,
    IUnifiedRepository<Order> orderRepository)
  {
    this.orderedItemRepository = orderedItemRepository;
    this.customerRepository = customerRepository;
    this.orderRepository = orderRepository;

    this.httpClient = new HttpClient();
  }

  public Order GetOrderById(Guid id)
  {
    return orderRepository.GetById(id);
  }

  public async Task<Order> CreateOrder(CreateOrderRequest createOrderRequest)
  {
    // find customer
    var customer = customerRepository.GetAll()
      .FirstOrDefault(x => x.Email == createOrderRequest.Customer.Email);

    // customer not found
    if (customer == null)
    {
      // PhoneNumberValidator.Validate(createOrderRequest.Customer.PhoneNumber);
      customer = new Customer
      {
        Name = createOrderRequest.Customer.Name,
        Address = createOrderRequest.Customer.Address,
        PhoneNumber = createOrderRequest.Customer.PhoneNumber,
        Email = createOrderRequest.Customer.Email
      };
      customerRepository.Add(customer);
    }

    // request items count from storage
    var missingItems = new List<CreateOrderRequestItem>();
    foreach (var item in createOrderRequest.Items)
    {
      var countInStorage = await GetQuantityAsync(item.ProductId);
      if (item.Quantity > countInStorage)
      {
        missingItems.Add(item);
      }
    }

    if (missingItems.Count > 0)
    {
      throw new ArgumentException($"Some of items are out of stock.");
    }

    // everything is fine
    var order = new Order
    {
      CustomerId = customer.Id,
      Status = OrderStatus.Created,
      OrderDate = DateTimeOffset.UtcNow,
      EstimatedDeliveryDate = EstimatedDeliveryTime()
    };

    var success = orderRepository.Add(order);
    if (success)
    {
      foreach (var item in createOrderRequest.Items)
      {
        orderedItemRepository.Add(new OrderedItem
        {
          ProductId = item.ProductId,
          ProductNumber = item.ProductNumber,
          Price = await GetPriceAsync(item.ProductId),
          Quantity = item.Quantity,
          OrderId = order.Id
        });
      }

      order.TotalPrice = await GetTotalPrice(order);
      orderRepository.Update(order);
      return order;
    }

    return null;
  }

  public async Task<decimal> GetTotalPrice(Order order)
  {
    var items = order.Items;
    decimal total = 0;
    foreach (var item in items)
    {
      total += await GetPriceAsync(item.ProductId);
    }

    return total;
  }

  public async Task<decimal> GetPriceAsync(Guid itemId)
  {
    var response =
      await httpClient.GetAsync(
        $"http://localhost:5246/product/price/{itemId}");

    if (response.IsSuccessStatusCode)
    {
      var content = await response.Content.ReadAsStringAsync();
      decimal price = int.Parse(content);
      return price;
    }

    return -1;
  }
  
  public DateTimeOffset EstimatedDeliveryTime()
  {
    Random random = new Random();
    int days = random.Next(2, 8);
    var currentDate = DateTimeOffset.UtcNow;
    var deliveryDate = currentDate.AddDays(days);
    return deliveryDate;
  }

  public Order UpdateOrder(Order order)
  {
    return orderRepository.Update(order);
  }

  public bool DeleteOrder(Guid id)
  {
    var order = orderRepository.GetById(id);
    return orderRepository.Delete(order);
  }

  public List<Order> GetAllOrders()
  {
    return orderRepository.GetAll().ToList();
  }

  public async Task<int> GetQuantityAsync(Guid itemId)
  {
    // Создайте HTTP-запрос к методу микросервиса Storage
    HttpResponseMessage response =
      await httpClient.GetAsync(
        $"http://localhost:5246/product/count/{itemId}");

    if (response.IsSuccessStatusCode)
    {
      string content = await response.Content.ReadAsStringAsync();
      int numberOfItems = int.Parse(content);
      return numberOfItems;
    }

    return -1;
  }

  public async Task SetOrderPayed(Guid orderId)
  {
    var order = orderRepository.GetById(orderId);
    order.Status = OrderStatus.Payed;
    orderRepository.Update(order);

    var customer = customerRepository.GetById(order.CustomerId);

    var request = new
    {
      Email = customer.Email,
      EstimatedDeliveryTime = order.EstimatedDeliveryDate,
      Price = order.TotalPrice,
      Name = customer.Name
    };

    var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

    try
    {
      var response =
        await httpClient.PostAsync("http://localhost:5271/email/send/",
          content);
      Console.WriteLine(response);
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
    }
    
  }
}
