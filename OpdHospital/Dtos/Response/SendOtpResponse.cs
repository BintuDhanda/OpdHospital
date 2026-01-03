using System;

namespace OpdHospital.Dtos.Response;

public class SendOtpResponse
{
    public string OtpReference { get; set; }
    public DateTime ExpiryAt { get; set; }
}
