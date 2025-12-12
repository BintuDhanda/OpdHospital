using OpdHospital.Interfaces;

namespace OpdHospital.Services
{
    public class FcmPushSenderService : IPushSender
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _cfg;
        private readonly ILogger<FcmPushSenderService> _logger;

        public FcmPushSenderService(HttpClient http, IConfiguration cfg, ILogger<FcmPushSenderService> logger)
        {
            _http = http;
            _cfg = cfg;
            _logger = logger;
        }

        public async Task SendPushAsync(string token, string title, string body)
        {
            var serverKey = _cfg["Fcm:ServerKey"];

            if (string.IsNullOrWhiteSpace(serverKey))
                throw new Exception("FCM ServerKey is missing from configuration.");

            if (string.IsNullOrWhiteSpace(token))
                throw new Exception("Push device token is empty.");

            var payload = new
            {
                to = token,
                notification = new
                {
                    title = title,
                    body = body,
                    sound = "default"
                },
                data = new
                {
                    click_action = "FLUTTER_NOTIFICATION_CLICK",
                    message = body
                }
            };

            var req = new HttpRequestMessage(HttpMethod.Post, "https://fcm.googleapis.com/fcm/send");
            req.Headers.TryAddWithoutValidation("Authorization", $"key={serverKey}");
            req.Content = JsonContent.Create(payload);

            var res = await _http.SendAsync(req);

            if (!res.IsSuccessStatusCode)
            {
                var err = await res.Content.ReadAsStringAsync();
                _logger.LogError("FCM push failed: {Error}", err);
                throw new Exception($"FCM Push failed: {err}");
            }

            _logger.LogInformation("FCM push sent to token={Token}", token);
        }
    }
}
