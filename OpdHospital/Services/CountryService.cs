using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models.Countries;

namespace OpdHospital.Services
{
    public class CountryService
    {
        private IGenericRepository<Country> _genericRepository;
        public CountryService(IGenericRepository<Country> genericRepository)
        {
            _genericRepository = genericRepository;
        }
    }
}
