using ApiApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiApplication.Repository.Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../ApiApplication.Repository/Data/DataSeed/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                if (brands?.Count > 0)
                {
                    foreach (var brand in brands)
                        await context.ProductBrands.AddAsync(brand);

                    await context.SaveChangesAsync();
                }
            }

            if (!context.ProductTypes.Any())
            {
                var typesData = File.ReadAllText("../ApiApplication.Repository/Data/DataSeed/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                if (types?.Count > 0)
                {
                    foreach (var type in types)
                        await context.ProductTypes.AddAsync(type);

                    await context.SaveChangesAsync();
                }
            }

            if (!context.Products.Any())
            {
                var productsData = File.ReadAllText("../ApiApplication.Repository/Data/DataSeed/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                if (products?.Count > 0)
                {
                    foreach (var product in products)
                        await context.Products.AddAsync(product);

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
