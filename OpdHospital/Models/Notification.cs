using System;

namespace OpdHospital.Models;

public class Notification
{
 public long NotificationId { get; set; }
 public string NotificationTitle { get; set; }
 public string NotificationMessage { get; set; }
 public long UserId { get; set; }
 public bool IsRead { get; set; }   
}
