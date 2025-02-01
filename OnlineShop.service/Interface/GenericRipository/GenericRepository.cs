using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Data;
using OnlineShop.Model.Models;

namespace OnlineShop.service.Interface.GenericRipository;

public class GenericRepository<T>(ApplicationDbContext dbContext) : IGenericInterface<T> where T : BaseModel
{
    public void Add(T entity)
    {
        dbContext.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        dbContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        dbContext.Set<T>().Remove(entity);
    }

    public async Task<bool> Save()
    {
        return await dbContext.SaveChangesAsync() > 0;
    }

    public bool IsExist(int id)
    {
        return dbContext.Set<T>().Any(e => e.Id == id);
    }

    public async Task<T?> GetById(int id)
    {
        return await dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await dbContext.Set<T>().ToListAsync();
    }
}