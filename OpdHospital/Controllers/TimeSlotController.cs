using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotController : GenericController<TimeSlot>
    {
        public TimeSlotController(IGenericService<TimeSlot> genericService) : base(genericService)
        {
        }
    }
}
