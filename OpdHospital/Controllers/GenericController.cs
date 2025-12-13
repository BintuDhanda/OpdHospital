using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Utilities;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T> : BaseController where T : class
    {
        private readonly IGenericService<T> _genericService;

        public GenericController(IGenericService<T> genericService)
        {
            _genericService = genericService;
        }

        [HttpGet]
        public Task<IActionResult> GetAll(int take=10, int skip=0) =>
            SafeExecute(async () =>
            {
                var query =  _genericService.GetAll();
                var count = query.Count();

                return Ok(Utilities.Response.Success(query.Skip(skip).Take(take).ToList(), count: count));
            });

        [HttpGet("{id}")]
        public Task<IActionResult> GetById(int id) =>
            SafeExecute(async () =>
            {
                var item = await _genericService.GetByIdAsync(id);
                if (item == null) 
                    return Ok(Utilities.Response.Success("Record not found"));

                return Ok(Utilities.Response.Success(item));
            });

        [HttpPost]
        public Task<IActionResult> Create(T entity) =>
            SafeExecute(async () =>
            {
                var created = await _genericService.AddAsync(entity);
                return Ok(Utilities.Response.Success(created, "Created successfully"));
            });

        [HttpPut("{id}")]
        public Task<IActionResult> Update(int id, T entity) =>
            SafeExecute(async () =>
            {
                var updated = await _genericService.UpdateAsync(id, entity);
                if (updated == null)
                    return Ok(Utilities.Response.Fail("Update failed"));

                return Ok(Utilities.Response.Success(updated, "Updated successfully"));
            });

        [HttpDelete("{id}")]
        public Task<IActionResult> Delete(int id) =>
            SafeExecute(async () =>
            {
                var deleted = await _genericService.DeleteAsync(id);
                if (!deleted)
                    return Ok(Utilities.Response.Fail("Delete failed"));

                return Ok(Utilities.Response.Success(null, "Deleted successfully"));
            });
    }
}
