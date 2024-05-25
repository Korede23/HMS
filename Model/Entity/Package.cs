namespace HMS.Model.Entity
{
    public class Package : BaseEntity
    {
        public string Name { get; set; }
        public string Items { get; set; }
        public double Price { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
