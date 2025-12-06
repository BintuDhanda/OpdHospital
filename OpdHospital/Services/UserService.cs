using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class UserService : GenericService<User>
    {
        private readonly IGenericRepository<User> _repository;

        public UserService(IGenericRepository<User> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
