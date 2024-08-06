using HMS.Dto;
using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;

namespace HMS.Implementation.Interface
{
    public interface IUserServices
    {
        Task<BaseResponse<Guid>> CreateUser(CreateUser request);
        Task<BaseResponse<Guid>> DeleteUserAsync(string id);
        Task<BaseResponse<UserDto>> GetUserByIdAsync(string Id);
        Task<BaseResponse<IList<UserDto>>> GetAllUserAsync();
        Task<BaseResponse<UserDto>> UpdateUser(string Id, UpdateUser request);
        Task<UserDto> GetUserByUserNAmeAsync(string username, string password);

    }
}
