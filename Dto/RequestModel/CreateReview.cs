using HMS.Model.Entity.Enum;

namespace HMS.Dto.RequestModel
{
    public class CreateReview
    {
        public string Comment { get; set; }
        public Review Rating { get; set; }
    }
}
