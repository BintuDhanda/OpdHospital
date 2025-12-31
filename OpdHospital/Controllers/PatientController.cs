using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;
using OpdHospital.Services;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : GenericController<Patient>
    {
        private readonly IPatientService _patientService;

        public PatientController(
            IGenericService<Patient> genericService,
            IPatientService patientService) : base(genericService)
        {
            _patientService = patientService;
        }

        [HttpGet("GetPatientBookByUserId/{userId}")]
        public Task<IActionResult> GetPatientBookByUserId([FromRoute] long userId) =>
            SafeExecute(async () =>
            {
                var result = await _patientService.GetPatientBookByUserId(userId);
                return Ok(result);
            });
    }
}
