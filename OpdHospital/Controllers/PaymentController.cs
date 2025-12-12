using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;
using OpdHospital.Services;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : GenericController<Payment>
    {
        public PaymentController(IGenericService<Payment> genericService) : base(genericService)
        {
        }
    }
}
