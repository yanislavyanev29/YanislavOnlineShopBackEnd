using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Models;
using YanislavOnlineShopBackEnd.Models;

namespace OnlineShop.DB
{
    
    
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext()
            {
            }

            public ApplicationDbContext(DbContextOptions dbContextOptions)
                : base(dbContextOptions)
            {
            }


            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer(@"Server=YANISLAV\SQLEXPRESS;Database=YanevOnlineDB;Integrated Security=true;");
                }
            }
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }

        



        

            public DbSet<OrderProduct> OrderProducts { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<OrderProduct>().HasKey(x => new {
                    x.OrderId,
                    x.ProductId
                });
            }
        
    }
}