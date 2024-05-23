using HMS.Dto;
using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;

namespace HMS.Implementation.Interface
{
    public interface IRoleService
    {
        Task<RoleResponseModel> CreateRole(CreateRole request);
        Task<BaseResponse> DeleteRole(int Id);
        Task<RoleResponseDto> GetAllRolesAsync();
        Task<RoleResponseDto> GetRoleByIdAsync(int Id);
        Task<BaseResponse> UpdateRole(int Id, UpdateRole request);

    }
}
