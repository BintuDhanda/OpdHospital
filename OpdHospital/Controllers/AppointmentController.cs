using Microsoft.AspNetCore.Mvc;
using OpdHospital.Controllers.Generics;
using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models.Appointments;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : GenericController<Appointment>
    {
        public AppointmentController(IGenericRepository<Appointment> genericRepository) : base(genericRepository)
        {
        }
    }
}
