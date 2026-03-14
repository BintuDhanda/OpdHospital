using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public interface IStateService
    {
        Task<IEnumerable<State>> GetStatesByCountryId(int countryId);
    }

    public class StateService : GenericService<State, int>, IStateService
    {
        private readonly IGenericRepository<State, int> _repository;
        public StateService(IGenericRepository<State, int> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<State>> GetStatesByCountryId(int countryId)
        {
            var states = _repository.GetAll();
            return states.Where(s => s.CountryId == countryId);
        }
    }
}
