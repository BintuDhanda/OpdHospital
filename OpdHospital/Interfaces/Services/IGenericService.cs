using OpdHospital.Models;

namespace OpdHospital.Interfaces
{
    public interface IGenericService<T, TKey> where T : class , IEntity<TKey>
    {
        IQueryable<T> GetAll();
        Task<T?> GetByIdAsync(TKey id);
        Task<T> AddAsync(T entity);
        Task<T?> UpdateAsync(T entity);
        Task<bool> DeleteAsync(TKey id);
    }
}

