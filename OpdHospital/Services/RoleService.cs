using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class RoleService:GenericService<Role, int>
    {
        private readonly IGenericRepository<Role, int> _repository;
        public RoleService(IGenericRepository<Role, int> repository):base(repository)
        {
            _repository = repository;
        }
    }
}
