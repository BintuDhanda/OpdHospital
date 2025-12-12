using Microsoft.Extensions.Options;
using OpdHospital.Interfaces;
using OpdHospital.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace OpdHospital.Services
{
    public class TwilioSmsSenderService : ISmsSender
    {
        private readonly TwilioSetting _cfg;
        public TwilioSmsSenderService(IOptions<TwilioSetting> cfg)
        {
            _cfg = cfg.Value;
        }

        public async Task SendSmsAsync(string toNumber, string message, CancellationToken ct = default)
        {
            // Initialize Twilio client
            TwilioClient.Init(_cfg.AccountSid, _cfg.AuthToken);

            try
            {
                // Send message
                var result = await MessageResource.CreateAsync(
                    body: message,
                    from: new Twilio.Types.PhoneNumber(_cfg.FromNumber),
                    to: new Twilio.Types.PhoneNumber(toNumber)
                );

                // Log or debug if needed
                Console.WriteLine($"SMS sent to {toNumber}, SID: {result.Sid}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SMS sending failed: {ex.Message}");
                throw; 
            }
        }
    }
}
