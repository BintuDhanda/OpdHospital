using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : GenericController<Invoice>
    {
        public InvoiceController(IGenericService<Invoice> genericService) : base(genericService)
        {
        }
    }
}
