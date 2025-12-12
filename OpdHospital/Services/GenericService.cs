using OpdHospital.Interfaces;

namespace OpdHospital.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;

        public GenericService(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<T> AddAsync(T entity)
        {
            return await _genericRepository.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _genericRepository.DeleteAsync(id);
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await _genericRepository.GetAllAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task<T?> UpdateAsync(int id, T entity)
        {
            return await _genericRepository.UpdateAsync(id, entity);
        }
    }
}
