using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class TimeSlotService : GenericService<TimeSlot>
    {
        private readonly IGenericRepository<TimeSlot> _repository;
        public TimeSlotService(IGenericRepository<TimeSlot> repository):base(repository)
        {
            _repository = repository;
        }
    }
}
