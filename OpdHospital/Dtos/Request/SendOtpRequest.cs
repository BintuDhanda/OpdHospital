using System;
using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Dtos.Request;

public class SendOtpRequest
{
    [Required]
    public string MobileNumber { get; set; }
}
