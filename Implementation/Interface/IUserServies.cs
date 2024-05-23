using HMS.Dto;
using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;

namespace HMS.Implementation.Interface
{
    public interface IUserServices
    {
        Task<UserResponseDto> GetUserByIdAsync(int Id);
       // List<UserDto> GetUserById(int Id);
        Task<BaseResponse> CreateUser(CreateUser request);
       // bool DeleteUser(int id);
        Task<BaseResponse> DeleteUserAsync(int id);
        Task<UserResponseDto> GetAllUserAsync();
        Task<BaseResponse> UpdateUser(int Id, UpdateUser request);
       // void UpdateUser(int Id, UpdateUser request);

    }
}
