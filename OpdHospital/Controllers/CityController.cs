using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;
using OpdHospital.Services;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : GenericController<City, int>
    {
        private readonly ICityService _cityService;
        public CityController(IGenericService<City, int> genericService, ICityService cityService) : base(genericService)
        {
            _cityService = cityService;
        }
        
        [HttpGet("GetCitiesByStateId/{stateId}")]
        public Task<IActionResult> GetCitiesByStateId(int stateId) =>
            SafeExecute(async () =>
            {
                return Ok(await _cityService.GetCitiesByStateId(stateId));
            });
    }
}
