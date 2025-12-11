using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Controllers.Generics;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalePartnerController : GenericController<SalePartner>
    {
        public SalePartnerController(IGenericRepository<SalePartner> genericRepository) : base(genericRepository)
        {
        }
    }
}
