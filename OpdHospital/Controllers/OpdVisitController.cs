using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpdVisitController : GenericController<OpdVisit>
    {
        public OpdVisitController(IGenericService<OpdVisit> genericService) : base(genericService)
        {
        }
    }
}
