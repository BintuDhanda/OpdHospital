using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpdHospital.Interfaces;
using OpdHospital.Models;
using OpdHospital.Services;

namespace OpdHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : GenericController<Notification>
    {
        private readonly INotificationService _notificationService;
        public NotificationController(IGenericService<Notification> service, INotificationService notificationService) : base(service)
        {
            _notificationService = notificationService;
        }

        [HttpGet("GetNotificationForUser/{userId}")]
        public Task<IActionResult> GetNotificationsForUser(long userId) =>
            SafeExecute(async () =>
            {
                return Ok(await _notificationService.GetAllNotificationsForUserAsync(userId));
            });
}}
