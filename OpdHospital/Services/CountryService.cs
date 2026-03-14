using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class CountryService : GenericService<Country, int>
    {
        private readonly IGenericRepository<Country, int> _genericRepository;
        public CountryService(IGenericRepository<Country, int> genericRepository) : base (genericRepository)
        {
            _genericRepository = genericRepository;
        }
    }
}
