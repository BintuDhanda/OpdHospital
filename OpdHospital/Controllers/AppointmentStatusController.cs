using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentStatusController : GenericController<AppointmentStatus>
    {
        public AppointmentStatusController(IGenericService<AppointmentStatus> genericService) : base(genericService)
        {
        }
    }
}
