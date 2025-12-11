using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Controllers.Generics;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAvailabilityController : GenericController<DoctorAvailability>
    {
        public DoctorAvailabilityController(IGenericRepository<DoctorAvailability> genericRepository) : base(genericRepository)
        {
        }
    }
}
