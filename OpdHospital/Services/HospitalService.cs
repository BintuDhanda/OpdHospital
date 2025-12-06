using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class HospitalService : GenericService<Hospital>
    {
        private readonly IGenericRepository<Hospital> _repository;
        public HospitalService(IGenericRepository<Hospital> repository):base(repository)
        {
            _repository = repository;
        }
    }
}
