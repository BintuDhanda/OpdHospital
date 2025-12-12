namespace OpdHospital.Interfaces
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string toNumber,string message, CancellationToken ct = default);
    }
}
