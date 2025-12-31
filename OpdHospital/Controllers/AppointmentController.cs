using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;
using OpdHospital.Services;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : GenericController<Appointment>
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(
            IGenericService<Appointment> genericService,
            IAppointmentService appointmentService
        ) : base(genericService)
        {
            _appointmentService = appointmentService;
        }

        // GET: api/appointment/user/5
        [HttpGet("User/{userId:long}")]
        public Task<IActionResult> GetAppointmentsByUserId([FromRoute] long userId) =>
            SafeExecute(async () =>
            {
                var result = await _appointmentService.GetAppointmentsByUserId(userId);
                return Ok(result);
            });
    }
}
