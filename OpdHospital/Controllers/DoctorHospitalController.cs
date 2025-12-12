using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorHospitalController : GenericController<DoctorHospital>
    {
        public DoctorHospitalController(IGenericService<DoctorHospital> genericService) : base(genericService)
        {
        }
    }
}
