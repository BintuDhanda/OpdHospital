using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Controllers.Generics;
using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models.Roles;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : GenericController<Role>
    {
        public RoleController(IGenericRepository<Role> genericRepository) : base(genericRepository)
        {
        }
    }
}
