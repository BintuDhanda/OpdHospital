using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefundController : GenericController<Refunds>
    {
        public RefundController(IGenericService<Refunds> genericService) : base(genericService)
        {
        }
    }
}
