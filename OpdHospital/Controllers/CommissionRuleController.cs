using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommissionRuleController : GenericController<CommissionRule>
    {
        public CommissionRuleController(IGenericService<CommissionRule> genericService) : base(genericService)
        {
        }
    }
}
