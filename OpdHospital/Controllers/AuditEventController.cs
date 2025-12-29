using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models.Audit;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditEventController : GenericController<AuditEvent>
    {
        public AuditEventController(IGenericService<AuditEvent> genericService, IJwtHelper jwtHelper) : base(genericService)
        {
            
        }
    }
}
