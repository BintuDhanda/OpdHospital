using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class RoleService:GenericService<Role>
    {
        private readonly IGenericRepository<Role> _repository;
        public RoleService(IGenericRepository<Role> repository):base(repository)
        {
            _repository = repository;
        }
    }
}
