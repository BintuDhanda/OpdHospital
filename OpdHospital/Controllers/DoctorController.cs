using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Controllers.Generics;
using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models.Doctors;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : GenericController<Doctor>
    {
        public DoctorController(IGenericRepository<Doctor> genericRepository) : base(genericRepository)
        {
        }
    }
}
