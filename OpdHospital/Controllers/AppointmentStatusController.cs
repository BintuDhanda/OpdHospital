using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Controllers.Generics;
using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentStatusController : GenericController<AppointmentStatus>
    {
        public AppointmentStatusController(IGenericRepository<AppointmentStatus> genericRepository) : base(genericRepository)
        {
        }
    }
}
