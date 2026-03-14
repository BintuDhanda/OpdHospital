using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;
using OpdHospital.Services;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : GenericController<State, int>
    {
        private readonly IStateService _stateService;
        public StateController(IGenericService<State, int> genericService, IStateService stateService) : base(genericService)
        {
            _stateService = stateService;
        }

        [HttpGet("GetStatesByCountryId/{countryId}")]
        public Task<IActionResult> GetStatesByCountryId(int countryId) =>
            SafeExecute(async () =>
            {
                return Ok(await _stateService.GetStatesByCountryId(countryId));
            });
    }
}
