public static class AppSettings
{
    // General
    public static string ApiKey { get; private set; } = string.Empty;
    public static string BaseUrl { get; private set; } = string.Empty;

    // JWT
    public static string JwtKey { get; private set; } = string.Empty;
    public static string JwtIssuer { get; private set; } = string.Empty;
    public static string JwtAudience { get; private set; } = string.Empty;
    public static int JwtExpiresInMinutes { get; private set; }
    public static string JwtSubject { get; private set; } = string.Empty;

    // Twilio
    public static string TwilioAccountSid { get; private set; } = string.Empty;
    public static string TwilioAuthToken { get; private set; } = string.Empty;
    public static string TwilioFromNumber { get; private set; } = string.Empty;

    // Smtp
    public static string SmtpHost { get; private set; } = string.Empty;
    public static int SmtpPort { get; private set; }
    public static bool SmtpUseSsl { get; private set; }
    public static string SmtpUser { get; private set; } = string.Empty;
    public static string SmtpPassword { get; private set; } = string.Empty;
    public static string SmtpFromName { get; private set; } = string.Empty;
    public static string SmtpFromEmail { get; private set; } = string.Empty;

    // OTP
    public static int OtpLength { get; private set; }
    public static int OtpExpiryMinutes { get; private set; }
    public static int OtpCooldownSeconds { get; private set; }
    public static int OtpDailyLimitPerIdentifier { get; private set; }

    public static void Load(IConfiguration config)
    {
        // Root keys
        ApiKey = config["ApiKey"] ?? string.Empty;
        BaseUrl = config["BaseUrl"] ?? string.Empty;

        // JWT
        JwtKey = config["Jwt:Key"] ?? string.Empty;
        JwtIssuer = config["Jwt:Issuer"] ?? string.Empty;
        JwtAudience = config["Jwt:Audience"] ?? string.Empty;
        JwtSubject = config["Jwt:Subject"] ?? string.Empty;
        JwtExpiresInMinutes = int.TryParse(config["Jwt:ExpiresInMinutes"], out var jwtExp) ? jwtExp : 60;

        // Twilio
        TwilioAccountSid = config["Twilio:AccountSid"] ?? string.Empty;
        TwilioAuthToken = config["Twilio:AuthToken"] ?? string.Empty;
        TwilioFromNumber = config["Twilio:FromNumber"] ?? string.Empty;

        // SMTP  
        SmtpHost = config["Smtp:Host"] ?? string.Empty;
        SmtpPort = int.TryParse(config["Smtp:Port"], out var smtpPort) ? smtpPort : 587;
        SmtpUseSsl = bool.TryParse(config["Smtp:UseSsl"], out var useSsl) && useSsl;
        SmtpUser = config["Smtp:User"] ?? string.Empty;
        SmtpPassword = config["Smtp:Password"] ?? string.Empty;
        SmtpFromName = config["Smtp:FromName"] ?? string.Empty;
        SmtpFromEmail = config["Smtp:FromEmail"] ?? string.Empty;

        // OTP
        OtpLength = int.TryParse(config["Otp:Length"], out var otpLen) ? otpLen : 6;
        OtpExpiryMinutes = int.TryParse(config["Otp:ExpiryMinutes"], out var expMin) ? expMin : 10;
        OtpCooldownSeconds = int.TryParse(config["Otp:CooldownSeconds"], out var cool) ? cool : 60;
        OtpDailyLimitPerIdentifier = int.TryParse(config["Otp:DailyLimitPerIdentifier"], out var limit) ? limit : 5;
    }
}
