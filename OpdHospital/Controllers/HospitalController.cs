using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;
using OpdHospital.Services;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : GenericController<Hospital, int>
    {
        private readonly IHospitalService _hospitalService;
        public HospitalController(IGenericService<Hospital, int> genericService, IHospitalService hospitalService) : base(genericService)
        {
            _hospitalService = hospitalService;
        }

        [HttpGet("GetHospitalsBySalesPartnerId/{salesPartnerId}")]
        public async Task<IActionResult> GetHospitalsBySalesPartnerId(int salesPartnerId)
        {
            var hospitals = await _hospitalService.GetHospitalsBySalesPartnerIdAsync(salesPartnerId);
            return Ok(hospitals);
        }
    }
}
