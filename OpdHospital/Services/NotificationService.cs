using System;
using Microsoft.EntityFrameworkCore;
using OpdHospital.Interfaces;
using OpdHospital.Models;
using OpdHospital.Utilities;

namespace OpdHospital.Services;

public interface INotificationService
{
    Task<ApiResponse?> GetAllNotificationsForUserAsync(long userId);
}

public class NotificationService : INotificationService
{
    private readonly IGenericService<Notification> _notificationService;
    public NotificationService(IGenericService<Notification> notificationService)
    {
        _notificationService = notificationService;
    }

    public async Task<ApiResponse?> GetAllNotificationsForUserAsync(long userId)
    {

        var query = _notificationService.GetAll()
            .Where(n => n.UserId == userId).OrderByDescending(n => n.NotificationId);

        var notifications = await query.ToListAsync();
        var totalRecords = await query.CountAsync();

        return Response.Success(notifications, "Notifications retrieved successfully", totalRecords) as ApiResponse;
    }

}
