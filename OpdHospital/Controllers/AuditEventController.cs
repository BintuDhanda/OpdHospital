using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models.Audit;
using OpdHospital.Utilities;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditEventController : GenericController<AuditEvent, long>
    {
        public AuditEventController(IGenericService<AuditEvent, long> genericService, IJwtHelper jwtHelper) : base(genericService)
        {
        }
    }
}
