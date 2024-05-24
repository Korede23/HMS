using HMS.Dto.ResponseModel;
using HMS.Model.Entity;

namespace HMS.Dto
{
    public class CustomerReviewDto
    {
        //public int Id { get; set; }
        public string Text { get; set; }
    }
    public class ReviewResponseDto : BaseResponse
    {
        public List<CustomerReviewDto> Data { get; set; }
    }
}
