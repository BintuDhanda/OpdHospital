using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class SpecializationService:GenericService<Specialization>
    {
        private readonly IGenericRepository<Specialization> _genericRepository;

        public SpecializationService(IGenericRepository<Specialization> genericRepository):base(genericRepository)
        {
            _genericRepository = genericRepository;
        }
    }
}
