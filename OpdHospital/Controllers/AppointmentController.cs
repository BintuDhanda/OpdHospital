using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : GenericController<Appointment>
    {
        public AppointmentController(IGenericService<Appointment> genericService) : base(genericService)
        {
        }
    }
}
