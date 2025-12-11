using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Controllers.Generics;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentStatusController : GenericController<PaymentStatus>
    {
        public PaymentStatusController(IGenericRepository<PaymentStatus> genericRepository) : base(genericRepository)
        {
        }
    }
}
