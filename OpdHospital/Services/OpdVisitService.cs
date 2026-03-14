using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class OpdVisitService : GenericService<OpdVisit, int>
    {
        private readonly IGenericRepository<OpdVisit, int> _repository;

        public OpdVisitService(IGenericRepository<OpdVisit, int> repository):base(repository)
        {
            _repository = repository;
        }
    }
}
