using OnlineShop.Model.Models;

namespace OnlineShop.service.Interface.GenericRipository;

public interface IGenericInterface<T> where T : BaseModel
{
    
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<bool> Save();
    bool IsExist(int id);
    Task<T> GetById(int id);
    Task<IReadOnlyList<T>> GetAll();

}