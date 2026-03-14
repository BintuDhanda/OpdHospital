using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : GenericController<Invoice, int>
    {
        public InvoiceController(IGenericService<Invoice, int> genericService) : base(genericService)
        {
        }
    }
}
