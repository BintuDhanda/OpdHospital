using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Controllers.Generics;
using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models.Specializations;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : GenericController<Specialization>
    {
        public SpecializationController(IGenericRepository<Specialization> genericRepository) : base(genericRepository)
        {
        }
    }
}
