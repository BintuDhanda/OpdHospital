using OpdHospital.Dtos;

namespace OpdHospital.Interfaces
{
    public interface INotificationService
    {
        Task<int> QueueNotificationAsync(NotificationRequestDto request);
    }
}
