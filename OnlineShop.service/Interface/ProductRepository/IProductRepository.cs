using OnlineShop.Model.Models;

namespace OnlineShop.service.Interface.ProductRepository;

public interface IProductRepository
{
    Task<IReadOnlyList<Product?>> GetAllAsync( string brand, string type);
    Task<Product?> GetByIdAsync(int id);
    void Add(Product product);
    void Update(Product product);
    void Delete(Product product);
    bool IsExists(int id);
    Task<bool> SaveChangesAsync();
    Task<IReadOnlyList<string>> GetBrandsAsync();
    Task<IReadOnlyList<string>> GetProductTypesAsync();
}