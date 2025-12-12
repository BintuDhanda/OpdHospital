using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;
using OpdHospital.Services;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentStatusController : GenericController<PaymentStatus>
    {
        public PaymentStatusController(IGenericService<PaymentStatus> genericService) : base(genericService)
        {
        }
    }
}
