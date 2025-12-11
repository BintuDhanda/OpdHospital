using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class PincodeService : GenericService<Pincode>
    {
        private readonly IGenericRepository<Pincode> _repository;

        public PincodeService(IGenericRepository<Pincode> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
