using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class RefundService:GenericService<Refunds>
    {
        private readonly IGenericRepository<Refunds> _repository;

        public RefundService(IGenericRepository<Refunds> repository):base(repository)
        {
            _repository = repository;
        }
    }
}
