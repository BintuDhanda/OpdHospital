using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAvailabilityController : GenericController<DoctorAvailability, long>
    {
        public DoctorAvailabilityController(IGenericService<DoctorAvailability, long> genericService) : base(genericService)
        {
        }
    }
}
