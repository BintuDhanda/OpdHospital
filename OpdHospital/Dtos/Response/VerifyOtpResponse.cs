using System;

namespace OpdHospital.Dtos.Response;

public class VerifyOtpResponse
{
    public string Token { get; set; }
    public long UserId { get; set; }
    public string[] Roles { get; set; }
}
