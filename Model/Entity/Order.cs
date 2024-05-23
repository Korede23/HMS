namespace HMS.Model.Entity
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
