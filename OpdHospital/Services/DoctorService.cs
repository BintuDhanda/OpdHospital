using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class DoctorService : GenericService<Doctor>
    {
        private readonly IGenericRepository<Doctor> _repository;

        public DoctorService(IGenericRepository<Doctor> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
