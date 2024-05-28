using HMS.Dto;
using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;

namespace HMS.Implementation.Interface
{
    public interface ICustomerReviewService
    {
        Task<BaseResponse> CreateReview(CreateReview request, int Id);
        Task<ReviewResponseDto> GetAllReviewAsync();
    }
}
