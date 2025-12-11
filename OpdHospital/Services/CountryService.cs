using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class CountryService : GenericService<Country>
    {
        private readonly IGenericRepository<Country> _genericRepository;
        public CountryService(IGenericRepository<Country> genericRepository) : base (genericRepository)
        {
            _genericRepository = genericRepository;
        }
    }
}
