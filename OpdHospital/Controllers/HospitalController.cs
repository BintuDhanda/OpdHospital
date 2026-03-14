using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : GenericController<Hospital, int>
    {
        public HospitalController(IGenericService<Hospital, int> genericService) : base(genericService)
        {
        }
    }
}
