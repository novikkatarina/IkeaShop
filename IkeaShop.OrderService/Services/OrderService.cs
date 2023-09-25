using CommonDataAccess;
using IkeaShop.OrderService.Data;
using IkeaShop.OrderService.Services.Interfaces;
using IkeaShop.OrderService.Models;

namespace IkeaShop.OrderService.Services;

using System.Collections.Generic;
using System.Linq;

public class OrderService : IOrderService
{
    private readonly IUnifiedRepository<Order> orderRepository;

    public OrderService(IUnifiedRepository<Order> orderRepository)
    {
        this.orderRepository = orderRepository;
    }

    public Order GetOrderById(Guid id)
    {
        return orderRepository.GetById(id);
    }

    public Order CreateOrder(Order order)
    {
        return order;
    }
    //
    // public Guid Id { get; set; }
    // public DateTime OrderDate { get; set; }
    // public DateTime EstimatedDeliveryDate { get; set; }
    // public OrderStatus Status { get; set; }
    //
    // public Guid CustomerId { get; set; }
    // public IEnumerable<Item> Items { get; set; }
    //
    //     orderRepository.Add(order);
    //     return order;
    // }

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

    public Order ChangeOrderSatusOrderStatus(Order order, OrderStatus status)
    {
        order.Status = status;
        return order;
    }
}