using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAvailabilityController : GenericController<DoctorAvailability>
    {
        public DoctorAvailabilityController(IGenericService<DoctorAvailability> genericService) : base(genericService)
        {
        }
    }
}
