using Microsoft.AspNetCore.Mvc;
using OpdHospital.Controllers.Generics;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : GenericController<User>
    {
        public UserController(IGenericRepository<User> repo) : base(repo)
        {
        }
    }
}
