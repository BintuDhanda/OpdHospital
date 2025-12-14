
namespace OpdHospital.Interfaces
{
    public interface IJwtHelper
    {
        string GenerateToken(int userId, string userName, string role);
        int GetUserId();
    }
}
