using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class PaymentMethodService:GenericService<PaymentMethod, int>
    {
        private readonly IGenericRepository<PaymentMethod, int> _genericRepository;

        public PaymentMethodService(IGenericRepository<PaymentMethod, int> genericRepository):base(genericRepository)
        {
            _genericRepository = genericRepository;
        }
    }
}
