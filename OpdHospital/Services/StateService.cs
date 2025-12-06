using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class StateService : GenericService<State>
    {
        private readonly IGenericRepository<State> _repository;
        public StateService(IGenericRepository<State> repository):base(repository)
        {
            _repository = repository;
        }
    }
}
