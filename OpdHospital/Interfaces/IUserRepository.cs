using OpdHospital.Models;

namespace OpdHospital.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
