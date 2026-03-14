using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;


namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : GenericController<Payment, long>
    {
        public PaymentController(IGenericService<Payment, long> genericService) : base(genericService)
        {
        }
    }
}
