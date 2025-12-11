using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class OpdVisitService : GenericService<OpdVisit>
    {
        private readonly IGenericRepository<OpdVisit> _repository;

        public OpdVisitService(IGenericRepository<OpdVisit> repository):base(repository)
        {
            _repository = repository;
        }
    }
}
