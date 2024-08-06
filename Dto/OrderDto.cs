using HMS.Dto.ResponseModel;
using HMS.Model.Entity;

namespace HMS.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Product Product { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
    
