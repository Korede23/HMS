using HMS.Dto;
using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;

namespace HMS.Implementation.Interface
{
    public interface ICustomerReviewService
    {
        Task<BaseResponse> CreateReview(CreateReview request, int Id);
        Task<BaseResponse> DeleteReview(int Id);
        Task<ReviewResponseDto> GetReviewByIdAsync(int Id);
        Task<ReviewResponseDto> GetAllReviewAsync();
        Task<BaseResponse> UpdateReview(int Id, UpdateReview request);
    }
}
