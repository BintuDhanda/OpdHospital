using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Controllers.Generics;
using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : GenericController<Hospital>
    {
        public HospitalController(IGenericRepository<Hospital> genericRepository) : base(genericRepository)
        {
        }
    }
}
