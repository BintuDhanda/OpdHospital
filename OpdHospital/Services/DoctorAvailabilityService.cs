using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class DoctorAvailabilityService : GenericService<DoctorAvailability, long>
    {
        private readonly IGenericRepository<DoctorAvailability, long> _repository;

        public DoctorAvailabilityService(IGenericRepository<DoctorAvailability, long> repository):base(repository)
        {
            _repository = repository;
        }
    }
}
