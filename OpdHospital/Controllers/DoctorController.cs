using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : GenericController<Doctor>
    {
        public DoctorController(IGenericService<Doctor> genericService) : base(genericService)
        {
        }
    }
}
