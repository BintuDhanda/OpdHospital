using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Controllers.Generics;
using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotController : GenericController<TimeSlot>
    {
        public TimeSlotController(IGenericRepository<TimeSlot> genericRepository) : base(genericRepository)
        {
        }
    }
}
