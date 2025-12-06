using OpdHospital.Interfaces;
using OpdHospital.Interfaces.IGenericRepositories;

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
            await _genericRepository.AddAsync(entity);
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);
            if (entity == null)
                return false;

            await _genericRepository.DeleteAsync(entity);

            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _genericRepository.GetAllAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task<T?> UpdateAsync(int id, T entity)
        {
            var existing = await _genericRepository.GetByIdAsync(id);
            if (existing == null)
                return null;

            await _genericRepository.UpdateAsync(entity);

            return entity;
        }
    }
}
