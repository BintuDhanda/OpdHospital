using System;
using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Dtos.Request;

public class SendOtpRequest
{
    [Required]
    [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Invalid mobile number")]
    public string MobileNumber { get; set; }
}
