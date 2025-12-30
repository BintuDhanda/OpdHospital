using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Services;
using OpdHospital.Utilities;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : BaseController
    {
        private readonly ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        [HttpGet()]
        public Task<IActionResult> Search([FromQuery] string query) =>
                SafeExecute(async () =>
                {
                    return Ok(await _searchService.Search(query));
                });
        }
}
