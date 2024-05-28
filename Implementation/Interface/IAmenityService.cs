using HMS.Dto;
using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;

namespace HMS.Implementation.Interface
{
    public interface IAmenityService
    {
        Task<BaseResponse> CreateAmenity(CreateAmenityRequestModel request);
        Task<BaseResponse> DeleteAmenity(int Id);
        Task<AmenityResponseDto> GetAmenityBYId(int Id);
        Task<AmenityResponseDto> GetAllAmenity();
        Task<BaseResponse> UpdateAmenity(int Id, UpdateAmenity request);
    }
}
