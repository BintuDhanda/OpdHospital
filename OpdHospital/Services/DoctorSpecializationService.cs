using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class DoctorSpecializationService : GenericService<DoctorSpecialization>
    {
        private readonly IGenericRepository<DoctorSpecialization> _repository;
        public DoctorSpecializationService(IGenericRepository<DoctorSpecialization> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
