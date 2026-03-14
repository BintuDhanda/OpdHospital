using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class CityService : GenericService<City, int>
    {
        private readonly IGenericRepository<City, int> _repository;
        public CityService(IGenericRepository<City, int> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
