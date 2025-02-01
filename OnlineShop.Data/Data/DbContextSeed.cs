using System.Text.Json;
using OnlineShop.Model.Models;

namespace OnlineShop.Data.Data;

public class DbContextSeed
{
    public static async Task SeedProducts(ApplicationDbContext context)
    {
        if (!context.Products.Any())
        {
            var productsData = await File.ReadAllTextAsync("../OnlineShop.Data/SeedData/products.json");
            
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);

            if (products == null) return;
            context.Products.AddRange(products);
            await context.SaveChangesAsync();
        }
    }
}