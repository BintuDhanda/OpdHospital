using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Controllers.Generics;
using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models.Pincodes;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PincodeController : GenericController<Pincode>
    {
        public PincodeController(IGenericRepository<Pincode> genericRepository) : base(genericRepository)
        {
        }
    }
}
