using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Controllers.Generics;
using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models.DoctorHospitals;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorHospitalController : GenericController<DoctorHospital>
    {
        public DoctorHospitalController(IGenericRepository<DoctorHospital> genericRepository) : base(genericRepository)
        {
        }
    }
}
