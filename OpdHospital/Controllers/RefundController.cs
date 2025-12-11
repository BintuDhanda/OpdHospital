using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Controllers.Generics;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefundController : GenericController<Refund>
    {
        public RefundController(IGenericRepository<Refund> genericRepository) : base(genericRepository)
        {
        }
    }
}
