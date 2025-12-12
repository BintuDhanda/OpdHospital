using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;
using OpdHospital.Services;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : GenericController<City>
    {
        public CityController(IGenericService<City> genericService) : base(genericService)
        {
        }
    }
}
