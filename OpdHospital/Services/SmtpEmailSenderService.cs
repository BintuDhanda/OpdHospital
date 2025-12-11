using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class SmtpEmailSenderService : IEmailSender
    {
        private readonly IEmailSender _emailSender;

        public Task SendEmailAsync(string to, string subject, string body, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
