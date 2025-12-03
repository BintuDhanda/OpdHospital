using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Controllers.Generics;
using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models.Departments;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : GenericController<Department>
    {
        public DepartmentController(IGenericRepository<Department> genericRepository) : base(genericRepository)
        {
        }
    }
}
