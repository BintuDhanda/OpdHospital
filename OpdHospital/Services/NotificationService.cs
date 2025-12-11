using OpdHospital.Database;
using OpdHospital.Dtos;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class NotificationService : INotificationService
    {
        private readonly AppDbContext _context;
        private readonly IPushSender _sender;

        public NotificationService(AppDbContext context, IPushSender sender)
        {
            _context = context;
            _sender = sender;
        }
        public async Task<int> QueueNotificationAsync(NotificationRequestDto req)
        {
            var entity = new NotificationMessage
            {
                Type = req.Type,
                Recipient = req.Recipient,
                Subject = req.Subject ?? string.Empty,
                Message = req.Message,
                Status = NotificationStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            await _context.NotificationMessages.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }
    }
}
