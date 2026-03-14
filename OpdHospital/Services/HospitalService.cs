using Microsoft.EntityFrameworkCore;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public interface IHospitalService
    {
        Task<IEnumerable<Hospital>> GetHospitalsBySalesPartnerIdAsync(int salesPartnerId);
    }
    public class HospitalService : GenericService<Hospital, int>, IHospitalService
    {
       
        public HospitalService(IGenericRepository<Hospital, int> repository):base(repository)
        {
            
        }

        public async Task<IEnumerable<Hospital>> GetHospitalsBySalesPartnerIdAsync(int salesPartnerId)
        {
            return await base.GetAll().Where(h => h.SalesPartnerId == salesPartnerId).ToListAsync();
        }
    }
}
