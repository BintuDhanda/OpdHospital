using OpdHospital.Models;

namespace OpdHospital.Dtos
{
    public class NotificationRequestDto
    {
        public NotificationType Type { get; set; }
        public string Recipient {  get; set; }
        public string? Subject { get; set; }
        public string Message { get; set; }
    }
}
