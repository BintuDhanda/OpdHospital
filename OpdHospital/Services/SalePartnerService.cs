using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class SalePartnerService : GenericService<SalePartner, int>
    {
        private readonly IGenericRepository<SalePartner, int> _repository;

        public SalePartnerService(IGenericRepository<SalePartner, int> repository):base(repository) 
        {
            _repository = repository;
        }
    }
}
