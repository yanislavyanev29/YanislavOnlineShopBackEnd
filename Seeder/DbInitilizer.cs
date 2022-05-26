using OnlineShop.DB;
using OnlineShop.DB.Models;

namespace YanislavOnlineShopBackEnd.Seeder
{
    public static class DbInitilizer
    {


        public static void Initilize(ApplicationDbContext context)
        {

            if (context.Products.Any()) return;

            var products = new List<Product>
            {
                new Product
                {
                    Name = "NIKE W AIR VAPORMAX 2021 FLYKNIT",
                    Description = "The Best Shoes",
                    Price = 200,
                    Brand = "Nike",
                    ImageUrl1 = "https://static.footshop.com/598636/136705.jpg",
                    ImageUrl2 = "https://static.footshop.com/598642/136705.jpg",
                    ImageUrl3 = "https://static.footshop.com/598645/136705.jpg",
                    QuantityInStock = 1,
                    Type = "Mens",
                    CategoryId = 2

                },
                new Product
                {
                    Name = "JORDAN PARIS SAINT-GERMAIN ",
                    Description = "The Best Thirt",
                    Price = 75,
                    Brand = "Jordan",
                    ImageUrl1 ="https://static.footshop.com/684046/183874.jpg",
                    ImageUrl2 ="https://static.footshop.com/684052/183874.jpg",
                    ImageUrl3 ="https://static.footshop.com/684049/183874.jpg",
                    QuantityInStock = 2,
                    Type = "Mens",
                    CategoryId = 1

                }



            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();
        }
    }
}
