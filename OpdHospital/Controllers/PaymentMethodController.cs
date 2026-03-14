using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : GenericController<PaymentMethod, int>
    {
        public PaymentMethodController(IGenericService<PaymentMethod> genericService) : base(genericService)
        {
        }
    }
}
