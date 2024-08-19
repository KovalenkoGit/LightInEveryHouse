namespace LightInEveryHouse.Models
{
    public class Group : BaseEntity
    {
        public Group() 
        {
            Addresses = new HashSet<Address>();
        }
        public string Name { get; set; }
        public string Description { get; set; } = "";
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
