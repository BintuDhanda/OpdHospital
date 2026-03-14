using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class TimeSlotService : GenericService<TimeSlot, long>
    {        
        public TimeSlotService(IGenericRepository<TimeSlot, long> repository):base(repository)
        {
            
        }
    }
}
