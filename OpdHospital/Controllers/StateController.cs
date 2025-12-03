using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Controllers.Generics;
using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models.States;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : GenericController<State>
    {
        public StateController(IGenericRepository<State> genericRepository) : base(genericRepository)
        {
        }
    }
}
