using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class GenericService<T, TKey> : IGenericService<T, TKey> where T : class, IEntity<TKey>
    {
        private readonly IGenericRepository<T, TKey> _genericRepository;

        public GenericService(IGenericRepository<T, TKey> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<T> AddAsync(T entity)
        {
            return await _genericRepository.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(TKey id)
        {
            return await _genericRepository.DeleteAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public async Task<T?> GetByIdAsync(TKey id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task<T?> UpdateAsync(T entity)
        {
            return await _genericRepository.UpdateAsync(entity);
        }
    }
}
