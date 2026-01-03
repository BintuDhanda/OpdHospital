using System;

namespace OpdHospital.Models;

public class OtpRequest
{
    public int Id { get; set; }
    public string MobileNumber { get; set; }
    public string OtpHash { get; set; }
    public DateTime ExpiryAt { get; set; }
    public int AttemptCount { get; set; }
}
