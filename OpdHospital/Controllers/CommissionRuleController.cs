using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Controllers.Generics;
using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models.CommissionsRules;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommissionRuleController : GenericController<CommissionRule>
    {
        public CommissionRuleController(IGenericRepository<CommissionRule> genericRepository) : base(genericRepository)
        {
        }
    }
}
