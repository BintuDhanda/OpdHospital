using OpdHospital.Interfaces.IGenericRepositories;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class DoctorHospitalService : GenericService<DoctorHospital>
    {
        private readonly IGenericRepository<DoctorHospital> _repository;

        public DoctorHospitalService(IGenericRepository<DoctorHospital> repository):base(repository)
        {
            _repository = repository;
        }
    }
}
