using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class HospitalService : GenericService<Hospital, int>
    {
       
        public HospitalService(IGenericRepository<Hospital, int> repository):base(repository)
        {
            
        }
    }
}
