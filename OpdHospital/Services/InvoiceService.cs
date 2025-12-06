using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class InvoiceService : GenericService<Invoice>
    {
        private readonly IGenericRepository<Invoice> _repository;
        public InvoiceService(IGenericRepository<Invoice> repository):base(repository)
        {
            _repository = repository;
        }
    }
}
