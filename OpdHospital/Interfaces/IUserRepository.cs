using OpdHospital.Models;

namespace OpdHospital.Interfaces
{
    public interface IUserRepository : IGenericRepository<User, long>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
