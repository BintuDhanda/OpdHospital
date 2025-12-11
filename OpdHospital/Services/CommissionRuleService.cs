using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class CommissionRuleService : GenericService<CommissionRule>
    {
        private readonly IGenericRepository<CommissionRule> _repository;

        public CommissionRuleService(IGenericRepository<CommissionRule> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
