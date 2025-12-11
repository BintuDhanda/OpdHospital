using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class PaymentMethodService:GenericService<PaymentMethod>
    {
        private readonly IGenericRepository<PaymentMethod> _genericRepository;

        public PaymentMethodService(IGenericRepository<PaymentMethod> genericRepository):base(genericRepository)
        {
            _genericRepository = genericRepository;
        }
    }
}
