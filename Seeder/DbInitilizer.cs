using Microsoft.AspNetCore.Identity;
using OnlineShop.DB;
using OnlineShop.DB.Models;

namespace YanislavOnlineShopBackEnd.Seeder
{
    public static class DbInitilizer
    {

        public static async Task Initilize(ApplicationDbContext context,
            UserManager<User> userManager)
        {


            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    UserName = "yanko",
                    Email = "yanko@gmail.com"
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member");


                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@test.com"
                };

                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.AddToRolesAsync(admin, new[] { "Member", "Admin" });
            }



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
                    //ImageUrl2 = "https://static.footshop.com/598642/136705.jpg",
                    //ImageUrl3 = "https://static.footshop.com/598645/136705.jpg",
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
                    //ImageUrl2 ="https://static.footshop.com/684052/183874.jpg",
                    //ImageUrl3 ="https://static.footshop.com/684049/183874.jpg",
                    QuantityInStock = 2,
                    Type = "Mens",
                    CategoryId = 1

                },


                new Product
                {
                    Name = "NIKE SPORTSWEAR CLUB HOODIE FZ FT",
                    Description = "The Best Thirt",
                    Price = 145,
                    Brand = "Nike",
                    ImageUrl1 ="https://static.footshop.com/281308/52632.jpg",
                    //ImageUrl2 ="https://static.footshop.com/281296/52632.jpg",
                    //ImageUrl3 ="https://static.footshop.com/281302/52632.jpg",
                    QuantityInStock = 2,
                    Type = "Mens",
                    CategoryId = 1

                },

                 new Product
                {
                    Name = "CALVIN KLEIN JEANS ",
                    Description = "CALVIN KLEIN JEANS FAUX LEATHER OVERSHIRT",
                    Price = 243,
                    Brand = "Calvin Klein",
                    ImageUrl1 ="https://static.footshop.com/562408/119569.jpg",
                    //ImageUrl2 ="https://static.footshop.com/562444/119569.jpg",
                    //ImageUrl3 ="https://static.footshop.com/562411/119569.jpg",
                    QuantityInStock = 5,
                    Type = "Womens",
                    CategoryId = 1

                },
                 new Product
                {
                    Name = "HAN KJØBENHAVN ",
                    Description = "CALVIN KLEIN JEANS FAUX LEATHER OVERSHIRT",
                    Price = 318,
                    Brand = "HAN KJØBENHAVN",
                    ImageUrl1 ="https://static.footshop.com/658132/156415.jpg",
                    //ImageUrl2 ="https://static.footshop.com/658138/156415.jpg",
                    //ImageUrl3 ="https://static.footshop.com/658129/156415.jpg",
                    QuantityInStock = 5,
                    Type = "Mens",
                    CategoryId = 1

                },
                  new Product
                {
                    Name = "NIKE AIR VAPORMAX 2021 FLYKNIT",
                    Description = "Armory Blue/ White-Lt Smoke Grey",
                    Price = 420,
                    Brand = "Nike",
                    ImageUrl1 ="https://static.footshop.com/575596/136759.jpg",
                    //ImageUrl2 ="https://static.footshop.com/575611/136759.jpg",
                    //ImageUrl3 ="https://static.footshop.com/575710/136759.jpg",
                    QuantityInStock = 10,
                    Type = "Mens",
                    CategoryId = 2

                },
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChangesAsync();
        }
    }
}
