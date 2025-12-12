using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PincodeController : GenericController<Pincode>
    {
        public PincodeController(IGenericService<Pincode> genericService) : base(genericService)
        {
        }
    }
}
