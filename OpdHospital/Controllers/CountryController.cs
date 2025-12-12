using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : GenericController<Country>
    {
        public CountryController(IGenericService<Country> genericService) : base(genericService)
        {
        }
    }
}
