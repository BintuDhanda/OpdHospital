using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class AppointmentStatusService : GenericService<AppointmentStatus>
    {
        private readonly IGenericRepository<AppointmentStatus> _repository;

        public AppointmentStatusService(IGenericRepository<AppointmentStatus> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
