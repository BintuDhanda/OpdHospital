using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class DoctorAvailabilityService : GenericService<DoctorAvailability>
    {
        private readonly IGenericRepository<DoctorAvailability> _repository;

        public DoctorAvailabilityService(IGenericRepository<DoctorAvailability> repository):base(repository)
        {
            _repository = repository;
        }
    }
}
