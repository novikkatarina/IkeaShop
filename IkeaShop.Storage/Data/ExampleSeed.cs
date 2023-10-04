using IkeaShop.Models;

namespace IkeaShop.Data;

public class ExampleSeed
{
    public static void SeedData(IApplicationBuilder applicationBuilder)
    {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<ApplicationDatabaseContext>();
        if (context.Products.Any())
        {
            return; // База данных уже заполнена
        }

        context.Database.EnsureCreated();

        var products = new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                ProductNumber = 65257,
                Price = 39900M,
                Quantity = 5,
                Room = ProductRoom.Bedroom,
                Title = "IDANAS",
                LinkFirst =
                    "https://www.ikea.com/gb/en/images/products/idanaes-upholstered-bed-frame-gunnared-dark-grey__0953724_pe802884_s5.jpg?f=xl",
                LinkSecond =
                    "https://www.ikea.com/gb/en/images/products/idanaes-upholstered-bed-frame-gunnared-dark-grey__0975281_pe812713_s5.jpg?f=xl"
            },
            new Product
            {
                Id = Guid.NewGuid(),
                ProductNumber = 27829,
                Price = 53900M,
                Quantity = 5,
                Room = ProductRoom.Bedroom,
                Title = "HEMNES",
                LinkFirst =
                    "https://www.ikea.com/gb/en/images/products/hemnes-day-bed-w-3-drawers-2-mattresses-white-afjaell-medium-firm__1180460_pe896336_s5.jpg?f=xl",
                LinkSecond =
                    "https://www.ikea.com/gb/en/images/products/hemnes-day-bed-w-3-drawers-2-mattresses-white-afjaell-medium-firm__1078996_pe857423_s5.jpg?f=xl"
            },

            new Product()
            {
                Id = Guid.NewGuid(),
                ProductNumber = 89067,
                Price = 23900M,
                Quantity = 0,
                Room = ProductRoom.Bedroom,
                Title = "SAGSTUA",
                LinkFirst =
                    "https://www.ikea.com/gb/en/images/products/sagstua-bed-frame-black-luroey__0783215_pe761511_s5.jpg?f=xl",
                LinkSecond =
                    "https://www.ikea.com/gb/en/images/products/sagstua-bed-frame-black-luroey__1102014_pe866839_s5.jpg?f=xl"
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                ProductNumber = 78992,
                Price = 25800M,
                Quantity = 10,
                Room = ProductRoom.Kitchen,
                Title = "METOD / MAXIMERA",
                LinkFirst =
                    "https://www.ikea.com/gb/en/images/products/metod-maximera-wall-cab-w-2-glass-doors-2-drawers-white-stensund-light-green__1105320_pe868065_s5.jpg?f=xl",
                LinkSecond =
                    "https://www.ikea.com/gb/en/images/products/metod-maximera-wall-cab-w-2-glass-doors-2-drawers-black-lerhyttan-black-stained__0260116_pe403633_s5.jpg?f=xl"
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                ProductNumber = 37892,
                Price = 4500M,
                Quantity = 9,
                Room = ProductRoom.Kitchen,
                Title = "ENHET",
                LinkFirst =
                    "https://www.ikea.com/gb/en/images/products/enhet-kitchen-white-grey-frame__1035193_pe837994_s5.jpg?f=xl",
                LinkSecond =
                    "https://www.ikea.com/gb/en/images/products/enhet-kitchen-white-grey-frame__1038054_pe839407_s5.jpg?f=xl"
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                ProductNumber = 40041,
                Price = 4500M,
                Quantity = 0,
                Room = ProductRoom.Kitchen,
                Title = "RASKOG",
                LinkFirst =
                    "https://www.ikea.com/gb/en/images/products/raskog-trolley-white__0503386_pe632627_s5.jpg?f=xl",
                LinkSecond =
                    "https://www.ikea.com/gb/en/images/products/raskog-trolley-white__1134462_pe878783_s5.jpg?f=xl"
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                ProductNumber = 40023,
                Price = 17900M,
                Quantity = 15,
                Room = ProductRoom.Bathroom,
                Title = "HEMNES",
                LinkFirst =
                    "https://www.ikea.com/gb/en/images/products/hemnes-mirror-cabinet-with-2-doors-white__1082337_pe858627_s5.jpg?f=xl",
                LinkSecond =
                    "https://www.ikea.com/gb/en/images/products/hemnes-mirror-cabinet-with-2-doors-white__0860724_pe555272_s5.jpg?f=xl"
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                ProductNumber = 40021,
                Price = 40100M,
                Quantity = 0,
                Room = ProductRoom.Bathroom,
                Title = "ENHET",
                LinkFirst =
                    "https://www.ikea.com/gb/en/images/products/enhet-storage-combination-white-oak-effect__1082987_pe858916_s5.jpg?f=xl",
                LinkSecond =
                    "https://www.ikea.com/gb/en/images/products/enhet-storage-combination-white-oak-effect__1096367_pe864337_s5.jpg?f=xl"
            },

            new Product()
            {
                Id = Guid.NewGuid(),
                ProductNumber = 4001,
                Price = 84400M,
                Quantity = 15,
                Room = ProductRoom.Bathroom,
                Title = "HEMNES / RATTVIKEN",
                LinkFirst =
                    "https://www.ikea.com/gb/en/images/products/hemnes-raettviken-bathroom-furniture-set-of-5-white-runskaer-tap__0730932_pe737860_s5.jpg?f=xl",
                LinkSecond =
                    "https://www.ikea.com/gb/en/images/products/hemnes-raettviken-bathroom-furniture-set-of-5-white-runskaer-tap__0756620_pe748993_s5.jpg?f=xl"
            },
        };


        context.Products.AddRange(products);
        context.SaveChanges();
    }
}