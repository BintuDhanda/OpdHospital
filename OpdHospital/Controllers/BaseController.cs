using Microsoft.AspNetCore.Mvc;

namespace OpdHospital.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected async Task<IActionResult> SafeExecute(Func<Task<IActionResult>> action)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState
                    .Where(kvp => kvp.Value?.Errors?.Count > 0)
                    .SelectMany(kvp => kvp.Value.Errors.Select(err =>
                    {
                        // If error has Exception (e.g. JSON parse), include its message too
                        return string.IsNullOrWhiteSpace(err.ErrorMessage) && err.Exception != null
                            ? err.Exception.Message
                            : err.ErrorMessage;
                    }))
                    .Where(m => !string.IsNullOrWhiteSpace(m))
                    .ToList();

                // If there are no string error messages but there are exceptions, try to capture them:
                if (!messages.Any() && ModelState.Values.SelectMany(v => v.Errors).Any(e => e.Exception != null))
                {
                    messages = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Where(e => e.Exception != null)
                        .Select(e => e.Exception.Message)
                        .ToList();
                }

                var aggregated = messages.Any()
                    ? string.Join(" | ", messages)
                    : "Validation failed";

                return Ok(Utilities.Response.Fail(aggregated));
            }

            try
            {
                return await action();
            }
            catch (Exception ex)
            {
                // return 200 with error message (as you required)
                return Ok(Utilities.Response.Fail(ex.Message));
            }
        }
    }
}
