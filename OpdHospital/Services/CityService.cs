using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class CityService : GenericService<City>
    {
        private readonly IGenericRepository<City> _repository;
        public CityService(IGenericRepository<City> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
