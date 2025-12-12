using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : GenericController<Department>
    {
        public DepartmentController(IGenericService<Department> genericService) : base(genericService)
        {
        }
    }
}
