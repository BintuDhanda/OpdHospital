using Microsoft.EntityFrameworkCore;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetCitiesByStateId(int stateId);
    }

    public class CityService : GenericService<City, int>, ICityService
    {
        private readonly IGenericRepository<City, int> _repository;
        public CityService(IGenericRepository<City, int> repository) : base(repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<City>> GetCitiesByStateId(int stateId)
        {
            return await _repository.GetAll().Where(c => c.StateId == stateId).ToListAsync();
        }
    }
}
