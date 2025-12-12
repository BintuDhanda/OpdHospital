using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : GenericController<Hospital>
    {
        public HospitalController(IGenericService<Hospital> genericService) : base(genericService)
        {
        }
    }
}
