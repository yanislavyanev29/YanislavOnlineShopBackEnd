using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Models;
using YanislavOnlineShopBackEnd.Models;

namespace OnlineShop.DB
{
    
    
        public class ApplicationDbContext : IdentityDbContext<User,Role, int>
    {
            public ApplicationDbContext()
            {
            }

            public ApplicationDbContext(DbContextOptions dbContextOptions)
                : base(dbContextOptions)
            {
            }



        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Clothing" },
                new Category { Id = 2, Name = "Shoes" },
                new Category { Id = 3, Name = "Accessories" }
                );

            modelBuilder.Entity<User>()
                .HasOne(a => a.Address)
                .WithOne()
                .HasForeignKey<UserAddress>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Role>()
                .HasData(
                      new Role {Id = 1, Name = "Member", NormalizedName = "MEMBER" },
                      new Role { Id = 2,Name = "Admin", NormalizedName = "ADMIN" }
                );


                modelBuilder.Entity<OrderProduct>().HasKey(x => new {
                    x.OrderId,
                    x.ProductId
                });
            }
        
    }
}