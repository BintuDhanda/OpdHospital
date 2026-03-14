using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : GenericController<UserRole, long>
    {
        public UserRoleController(IGenericService<UserRole> genericService) : base(genericService)
        {
        }
    }
}
