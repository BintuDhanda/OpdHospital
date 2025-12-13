using Microsoft.EntityFrameworkCore;
using OpdHospital.Database;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class NotificationBackgroundService 
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<NotificationBackgroundService> _logger;

        public NotificationBackgroundService(
            IServiceScopeFactory scopeFactory,
            ILogger<NotificationBackgroundService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }
        protected  async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Notification Worker Started");

            while (!stoppingToken.IsCancellationRequested)
            {
                await ProcessNotifications(stoppingToken);

                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }
        private async Task ProcessNotifications(CancellationToken ct)
        {
            using var scope = _scopeFactory.CreateScope();

            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var email = scope.ServiceProvider.GetRequiredService<IEmailSender>();
            var sms = scope.ServiceProvider.GetRequiredService<ISmsSender>();
            var push = scope.ServiceProvider.GetRequiredService<IPushSender>();

            var pending = await db.NotificationMessages
                .Where(n => n.Status == NotificationStatus.Pending)
                .OrderBy(n => n.CreatedAt)
                .Take(20)
                .ToListAsync(ct);

            if (!pending.Any()) return;

            foreach (var n in pending)
            {
                try
                {
                    switch (n.Type)
                    {
                        case NotificationType.Email:
                            await email.SendEmailAsync(n.Recipient, n.Subject, n.Message);
                            break;

                        case NotificationType.SMS:
                            await sms.SendSmsAsync(n.Recipient, n.Message);
                            break;

                        case NotificationType.Push:
                            await push.SendPushAsync(n.Recipient, n.Subject, n.Message);
                            break;
                    }

                    n.Status = NotificationStatus.Sent;
                    n.SentAt = DateTime.UtcNow;
                }
                catch (Exception ex)
                {
                    n.Status = NotificationStatus.Failed;
                    n.Error = ex.Message;

                    _logger.LogError(ex, "Failed to send notification ID={Id}", n.Id);
                }
            }
            await db.SaveChangesAsync(ct);
        }
    }
}
