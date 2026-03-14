using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalePartnerController : GenericController<SalePartner, int>
    {
        public SalePartnerController(IGenericService<SalePartner, int> genericService) : base(genericService)
        {
        }
    }
}
