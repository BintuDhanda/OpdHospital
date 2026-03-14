using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class PincodeService : GenericService<Pincode, long>
    {
        private readonly IGenericRepository<Pincode, long> _repository;

        public PincodeService(IGenericRepository<Pincode, long> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
