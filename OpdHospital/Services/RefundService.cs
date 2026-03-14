using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class RefundService:GenericService<Refunds, long>
    {
        private readonly IGenericRepository<Refunds, long> _repository;

        public RefundService(IGenericRepository<Refunds, long> repository):base(repository)
        {
            _repository = repository;
        }
    }
}
