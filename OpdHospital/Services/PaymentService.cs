using OpdHospital.Interfaces.IGenericRepositories;

namespace OpdHospital.Services
{
    public class PaymentService : GenericService<PaymentService>
    {
        private readonly IGenericRepository<PaymentService> _repository;
        public PaymentService(IGenericRepository<PaymentService> repository):base(repository)
        {
            _repository = repository;
        }
    }
}
