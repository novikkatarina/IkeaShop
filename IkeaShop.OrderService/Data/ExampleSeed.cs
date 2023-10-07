using IkeaShop.OrderService.Models;

namespace IkeaShop.OrderService.Data;

public class ExampleSeed
{
    public static void SeedData(IApplicationBuilder applicationBuilder)
    {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<ApplicationDatabaseContext>();
        if (context.Customers.Any() || context.Orders.Any() || context.Items.Any())
        {
            return; // База данных уже заполнена
        }

        context.Database.EnsureCreated();

        var customers = new List<Customer>
        {
            new Customer
            {
                Id = Guid.NewGuid(), 
                PhoneNumber = "123-456-7890", Name = "Customer 1", Address = "Address 1",
                Email = "customer1@example.com"
            },
            new Customer
            {
                Id = Guid.NewGuid(), 
                PhoneNumber = "987-654-3210", Name = "Customer 2", Address = "Address 2",
                Email = "customer2@example.com"
            }
        };

        context.Customers.AddRange(customers);
        context.SaveChanges();

        // Создаем несколько заказов
        var orders = new List<Order>
        {
            new Order
            {
                CustomerId = customers[0].Id, 
                Items = new List<OrderedItem>
                {
                    new OrderedItem
                    {
                        Id = Guid.NewGuid(), ProductNumber = 1, Price = 10.99M, Quantity = 2,
                    },
                    new OrderedItem
                    {
                        Id = Guid.NewGuid(), ProductNumber = 2, Price = 11.99M, Quantity = 5,
                    }
                },
            },
            new Order
            {
                Id = Guid.NewGuid(), CustomerId = customers[1].Id, Items = new List<OrderedItem>
                {
                    new OrderedItem
                    {
                        Id = Guid.NewGuid(), ProductNumber = 3, Price = 15.99M, Quantity = 1,
                    },
                    new OrderedItem
                    {
                        Id = Guid.NewGuid(), ProductNumber = 4, Price = 5.99M, Quantity = 12,
                    }
                }
            }
        };

        context.Orders.AddRange(orders);
        context.SaveChanges();
    }
}