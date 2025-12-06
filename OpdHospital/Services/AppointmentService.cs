using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class AppointmentService : GenericService<Appointment>
    {
        private readonly IGenericRepository<Appointment> _genericRepository;
        public AppointmentService(IGenericRepository<Appointment> genericRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
        }
    }
}
