using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Data;
using OnlineShop.Model.Models;


namespace OnlineShop.service.Interface.ProductRepository;

public class ProductRepository(ApplicationDbContext dbContext) : IProductRepository
{
    public async Task<IReadOnlyList<Product?>> GetAllAsync(string brand, string type)
    {
        var products = await dbContext.Products
            .Where(p => p != null && (p.Brand == brand || p.Type == type)).ToListAsync();
        return await dbContext.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await dbContext.Products.FirstOrDefaultAsync(x =>x!.Id == id);
    }

    public void Add(Product product)
    {
        dbContext.Products.Add(product);
    }

    public void Update(Product product)
    {
        dbContext.Products.Update(product);
    }

    public void Delete(Product product)
    {
        dbContext.Products.Remove(product);
    }

    public bool IsExists(int id)
    {
        return dbContext.Products.Any(x => x.Id == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<IReadOnlyList<string>> GetBrandsAsync()
    {
        return await dbContext.Products.Select(x => x.Brand).Distinct().ToListAsync();
    }

    public async Task<IReadOnlyList<string>> GetProductTypesAsync()
    {
        return await dbContext.Products.Select(x => x.Type).Distinct().ToListAsync();
    }
}