using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : GenericController<User>
    {
        public UserController(IGenericService<User> repo) : base(repo)
        {
        }
    }
}
