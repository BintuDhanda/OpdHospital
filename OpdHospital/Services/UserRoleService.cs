using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class UserRoleService:GenericService<UserRole>
    {
        private readonly IGenericRepository<UserRole> _repository;

        public UserRoleService(IGenericRepository<UserRole> repository):base(repository)
        {
            _repository = repository;
        }
    }
}
