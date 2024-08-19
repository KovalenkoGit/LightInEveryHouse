namespace LightInEveryHouse.Models
{
    public class Schedule : BaseEntity
    {
        public int AddressId { get; set; }
        public string Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }
        public int Archive { get; set; } = 0;
        public virtual Address Address { get; set; }

    }
}
