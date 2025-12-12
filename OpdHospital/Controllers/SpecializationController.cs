using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : GenericController<Specialization>
    {
        public SpecializationController(IGenericService<Specialization> genericService) : base(genericService)
        {
        }
    }
}
