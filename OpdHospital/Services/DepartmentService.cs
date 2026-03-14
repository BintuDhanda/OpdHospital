using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class DepartmentService : GenericService<Department, int>
    {
        private readonly IGenericRepository<Department, int> _repository;

        public DepartmentService(IGenericRepository<Department, int> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
