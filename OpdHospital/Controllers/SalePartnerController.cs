using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalePartnerController : GenericController<SalePartner>
    {
        public SalePartnerController(IGenericService<SalePartner> genericService) : base(genericService)
        {
        }
    }
}
