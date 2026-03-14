using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class InvoiceService : GenericService<Invoice, int>
    {
        private readonly IGenericRepository<Invoice, int> _repository;
        public InvoiceService(IGenericRepository<Invoice, int> repository):base(repository)
        {
            _repository = repository;
        }
    }
}
