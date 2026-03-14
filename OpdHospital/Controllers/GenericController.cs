using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;
using OpdHospital.Utilities;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T, Tkey> : BaseController where T : class, IEntity<Tkey>
    {
        private readonly IGenericService<T, Tkey> _genericService;

        public GenericController(IGenericService<T, Tkey> genericService)
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
        public Task<IActionResult> GetById(Tkey id) =>
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
        public Task<IActionResult> Update(Tkey id, T entity) =>
            SafeExecute(async () =>
            {
                // Preserve audit fields (CreatedAt/CreatedBy) when they are not supplied by the client.
                var existing = await _genericService.GetByIdAsync(id);
                if (existing == null)
                    return Ok(Utilities.Response.Fail("Record not found"));

                if (existing is BaseEntity existingBase && entity is BaseEntity incomingBase)
                {
                    incomingBase.CreatedAt = existingBase.CreatedAt;
                    incomingBase.CreatedBy = existingBase.CreatedBy;
                }

                entity.Id = id;
                var updated = await _genericService.UpdateAsync(entity);
                if (updated == null)
                    return Ok(Utilities.Response.Fail("Update failed"));

                return Ok(Utilities.Response.Success(updated, "Updated successfully"));
            });

        [HttpDelete("{id}")]
        public Task<IActionResult> Delete(Tkey id) =>
            SafeExecute(async () =>
            {
                var deleted = await _genericService.DeleteAsync(id);
                if (!deleted)
                    return Ok(Utilities.Response.Fail("Delete failed"));

                return Ok(Utilities.Response.Success(null, "Deleted successfully"));
            });
    }
}
