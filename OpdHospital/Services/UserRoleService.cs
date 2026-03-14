using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class UserRoleService:GenericService<UserRole, long>
    {
        private readonly IGenericRepository<UserRole, long> _repository;

        public UserRoleService(IGenericRepository<UserRole, long> repository):base(repository)
        {
            _repository = repository;
        }
    }
}
