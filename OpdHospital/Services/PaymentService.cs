using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class PaymentService : GenericService<Payment, long>
    {
        private readonly IGenericRepository<Payment, long> _repository;
        public PaymentService(IGenericRepository<Payment, long> repository):base(repository)
        {
            _repository = repository;
        }
    }
}
