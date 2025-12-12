namespace OpdHospital.Interfaces
{
    public interface IPushSender
    {
        Task SendPushAsync(string deviceToken, string title, string body);
    }
}
