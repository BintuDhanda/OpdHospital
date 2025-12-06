using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class PaymentStatusService : GenericService<PaymentStatus>
    {
        private readonly IGenericRepository<PaymentStatus> _repository;

        public PaymentStatusService(IGenericRepository<PaymentStatus> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
