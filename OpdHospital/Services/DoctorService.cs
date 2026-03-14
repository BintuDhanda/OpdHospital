using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class DoctorService : GenericService<Doctor, int>, IDoctorService
    {
        private readonly IGenericRepository<Doctor, int> _repository;

        public DoctorService(IGenericRepository<Doctor, int> repository) : base(repository)
        {
            _repository = repository;
        }
    }

    public interface IDoctorService
    {
        
    }
}
