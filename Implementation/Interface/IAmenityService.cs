using HMS.Dto;
using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;

namespace HMS.Implementation.Interface
{
    public interface IAmenityService
    {
        Task<BaseResponse<Guid>> CreateAmenity(CreateAmenityRequestModel request);
        Task<BaseResponse<AmenityDto>> UpdateAmenity(int Id, UpdateAmenity request);
        Task<BaseResponse<IList<AmenityDto>>> GetAllAmenity();
        Task<BaseResponse<AmenityDto>> GetAmenityById(int Id);
        Task<BaseResponse<Guid>> DeleteAmenity(int Id);
    }
}
