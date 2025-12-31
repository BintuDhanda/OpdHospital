using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class DoctorService : GenericService<Doctor>, IDoctorService
    {
        private readonly IGenericRepository<Doctor> _repository;

        public DoctorService(IGenericRepository<Doctor> repository) : base(repository)
        {
            _repository = repository;
        }
    }

    public interface IDoctorService
    {
        
    }
}
