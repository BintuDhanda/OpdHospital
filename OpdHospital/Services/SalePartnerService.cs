using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class SalePartnerService : GenericService<SalePartner>
    {
        private readonly IGenericRepository<SalePartner> _repository;

        public SalePartnerService(IGenericRepository<SalePartner> repository):base(repository) 
        {
            _repository = repository;
        }
    }
}
