using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;
using OpdHospital.Services;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : GenericController<Doctor, int>
    {
        private  readonly IDoctorService _doctorService;

        public DoctorController(IGenericService<Doctor, int> genericService, IDoctorService doctorService) : base(genericService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("GetDoctorsByHospital/{hospitalId}")]
        public async Task<IActionResult> GetDoctorsByHospitalId(int hospitalId)
        {
            var doctors = await _doctorService.GetDoctorsByHospitalId(hospitalId);
            return Ok(doctors);
        }
    }
}
