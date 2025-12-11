using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class PatientService : GenericService<Patient>
    {
        private readonly IGenericRepository<Patient> _repository;
        public PatientService(IGenericRepository<Patient> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
