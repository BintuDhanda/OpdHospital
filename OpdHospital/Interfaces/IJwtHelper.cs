
namespace OpdHospital.Interfaces
{
    public interface IJwtHelper
    {
        string GenerateToken(long userId, string userName, string[] role);
        long GetUserId();
    }
}
