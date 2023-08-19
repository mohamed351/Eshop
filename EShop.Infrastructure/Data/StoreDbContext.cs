using Microsoft.EntityFrameworkCore;
using EShop.Core.Entities;
using System.Reflection;
using EShop.Core.Entities.Orders;

namespace EShop.Infrastructure.Data
{
    public class StoreDbContext:DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            :base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductBrand> ProductBrands { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }


        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
