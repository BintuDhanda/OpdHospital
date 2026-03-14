using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class CommissionRuleService : GenericService<CommissionRule, int>
    {
        private readonly IGenericRepository<CommissionRule, int> _repository;

        public CommissionRuleService(IGenericRepository<CommissionRule, int> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
