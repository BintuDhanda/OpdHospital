using Microsoft.OpenApi.Writers;
using OpdHospital.Dtos.UsersDto;
using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models;

namespace OpdHospital.Interfaces.IUsersRepositories
{
    public interface IUserRepository : IGenericRepository<User> 
    {
        Task<User> GetByEmailAsync(string email);
    }
}
