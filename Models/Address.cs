namespace LightInEveryHouse.Models
{
    public class Address : BaseEntity
    {
        public Address()
        {
            Schedules = new HashSet<Schedule>();
        }
        public int GroupId { get; set; }
        public string StreetAddress { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }


    }
}
