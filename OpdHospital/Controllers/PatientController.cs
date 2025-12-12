using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : GenericController<Patient>
    {
        public PatientController(IGenericService<Patient> genericService) : base(genericService)
        {
        }
    }
}
