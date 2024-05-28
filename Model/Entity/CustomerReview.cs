using HMS.Model.Entity.Enum;

namespace HMS.Model.Entity
{
    public class CustomerReview : BaseEntity
    {
        public string Comment { get; set; }
        public Review Rating { get; set; }
    }
}
