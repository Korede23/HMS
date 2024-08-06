using HMS.Dto.ResponseModel;
using HMS.Model.Entity;
using HMS.Model.Entity.Enum;

namespace HMS.Dto
{
    public class CustomerReviewDto
    {
        //public int Id { get; set; }
        public string Comment { get; set; }
        public Review Rating { get; set; }
    }
}
