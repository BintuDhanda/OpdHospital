using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefundController : GenericController<Refunds, long>
    {
        public RefundController(IGenericService<Refunds, long> genericService) : base(genericService)
        {
        }
    }
}
