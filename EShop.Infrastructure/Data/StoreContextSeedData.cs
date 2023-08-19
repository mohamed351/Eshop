using EShop.Core.Entities;
using EShop.Core.Entities.Orders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EShop.Infrastructure.Data
{
    public class StoreContextSeedData
    {
        public static async Task SeedAsync(StoreDbContext context)
        {
            if (!context.ProductBrands.Any())
            {
                var brandsJson = File.ReadAllText("../EShop.Infrastructure/Data/SeedingData/brands.json");
                var brandsObject = JsonSerializer.Deserialize<List<ProductBrand>>(brandsJson);
                context.ProductBrands.AddRange(brandsObject);
            }
            if (!context.ProductBrands.Any())
            {
                var productTypeJson = File.ReadAllText("../EShop.Infrastructure/Data/SeedingData/types.json");
                var productTypes = JsonSerializer.Deserialize<List<ProductType>>(productTypeJson);
                context.ProductTypes.AddRange(productTypes);
            }

            if (!context.Products.Any())
            {
                var productJson = File.ReadAllText("../EShop.Infrastructure/Data/SeedingData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productJson);
                context.Products.AddRange(products);
            }
            if (!context.DeliveryMethods.Any())
            {
                var deliveryMethodJson = File.ReadAllText("../EShop.Infrastructure/Data/SeedingData/delivery.json");
                var deliveryMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryMethodJson);
                context.DeliveryMethods.AddRange(deliveryMethods);
            }

            if (context.ChangeTracker.HasChanges())
            {
               await context.SaveChangesAsync();
            }
        }
    }
}
