using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : GenericController<Role>
    {
        public RoleController(IGenericService<Role> genericService) : base(genericService)
        {
        }
    }
}
