using Core.Entites;
using Core.Entites.OrderAggregate;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext storeContext, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!storeContext.ProductBrands.Any())
                {
                    var brandData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonConvert.DeserializeObject<List<ProductBrand>>(brandData);

                    foreach (var item in brands)
                    {
                        storeContext.ProductBrands.Add(item);
                    }
                    await storeContext.SaveChangesAsync();
                }

                if (!storeContext.ProductTypes.Any())
                {
                    var productTypesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var productType = JsonConvert.DeserializeObject<List<ProductType>>(productTypesData);
                    foreach (var item in productType)
                    {
                        storeContext.ProductTypes.Add(item);
                    }
                    await storeContext.SaveChangesAsync();
                }

                if (!storeContext.Products.Any())
                {
                    var productData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonConvert.DeserializeObject<List<Product>>(productData);
                    foreach (var item in products)
                    {
                        storeContext.Products.Add(item);
                    }
                    await storeContext.SaveChangesAsync();
                }

                if (!storeContext.DeliveryMethods.Any())
                {
                    var dmData = File.ReadAllText("../Infrastructure/Data/SeedData/delivery.json");
                    var methods = JsonConvert.DeserializeObject<List<DeliveryMethod>>(dmData);
                    foreach (var item in methods)
                    {
                        storeContext.DeliveryMethods.Add(item);
                    }
                    await storeContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex, "Failed while seeding");
            }
        }
    }
}
