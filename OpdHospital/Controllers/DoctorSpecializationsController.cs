using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorSpecializationsController : GenericController<DoctorSpecialization>
    {
        public DoctorSpecializationsController(IGenericService<DoctorSpecialization> genericService) : base(genericService)
        {
        }
    }
}
