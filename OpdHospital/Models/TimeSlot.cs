namespace OpdHospital.Models
{
    public class TimeSlot : BaseEntity, IEntity<long>
    {
        public long Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
