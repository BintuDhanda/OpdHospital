using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class RefundService:GenericService<Refund>
    {
        private readonly IGenericRepository<Refund> _repository;

        public RefundService(IGenericRepository<Refund> repository):base(repository)
        {
            _repository = repository;
        }
    }
}
