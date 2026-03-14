using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class StateService : GenericService<State, int>
    {
        private readonly IGenericRepository<State, int> _repository;
        public StateService(IGenericRepository<State, int> repository):base(repository)
        {
            _repository = repository;
        }
    }
}
