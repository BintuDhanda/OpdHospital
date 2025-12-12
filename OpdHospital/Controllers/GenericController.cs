using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T> : ControllerBase where T : class
    {
        private readonly IGenericService<T> _genericService;

        public GenericController(IGenericService<T> genericService)
        {
           _genericService = genericService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _genericService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _genericService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(T entity)
        {
            var newEntity = await _genericService.AddAsync(entity);
            return Ok(newEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, T entity)
        {
            var updated = await _genericService.UpdateAsync(id, entity);
            if (updated == null) return NotFound("Update Failed");
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _genericService.DeleteAsync(id);
            if (!deleted) return NotFound("Delete Failed");
            return Ok("Deleted Successfully");
        }
    }
}
