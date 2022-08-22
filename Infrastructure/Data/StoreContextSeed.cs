using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    //This class is used to seed the data from the json files we have in seed data folder
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                //If there are no product brands in DB, we then need to seed the data
                if (!context.ProductBrands.Any())
                {
                    //Get the brands json file
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    //Serialize it using JSON Serializer
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    //Add to DB via context
                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                //If there are no product types in DB, we then seed the data
                if (!context.ProductTypes.Any())
                {
                    //Get the brands json file
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    //Serialize it using JSON Serializer
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    //Add to DB via context
                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                //If there are no products in DB, we then seed the data
                if (!context.Products.Any())
                {
                    //Get the brands json file
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    //Serialize it using JSON Serializer
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    //Add to DB via context
                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();

                logger.LogError(ex.Message);
            }
        }
    }
}