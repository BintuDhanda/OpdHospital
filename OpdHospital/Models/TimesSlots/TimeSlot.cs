using OpdHospital.Models.Base;

namespace OpdHospital.Models.TimesSlots
{
    public class TimeSlot:BaseEntity
    {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
