using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PincodeController : GenericController<Pincode, long>
    {
        public PincodeController(IGenericService<Pincode, long> genericService) : base(genericService)
        {
        }
    }
}
