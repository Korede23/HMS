using HMS.Dto;
using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;
using HMS.Implementation.Interface;
using HMS.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace HMS.Implementation.Services
{
    public class RoleService : IRoleService
    {
        private readonly ApplicationDbContext _dbContext;

        public RoleService(ApplicationDbContext dbContex)
        {
            _dbContext = dbContex;
        }
        public async Task<RoleResponseModel> CreateRole(CreateRole request)
        {
            if (request != null)
            {
                var role = new Role
                {
                    Name = request.Name
                };
                await _dbContext.Roles.AddAsync(role);
                await _dbContext.SaveChangesAsync();
            }
            return new RoleResponseModel
            {
                Success = true,
                Message = "Role Created Succesfully"
            };
        }

        public async Task<BaseResponse> DeleteRole(int Id)
        {
            var role = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Id == Id);
            if (role != null)
            {
                _dbContext.Roles.Remove(role);
            }
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = "Role has been deleted Succesfully"
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Failed to delete Role",
                    Hasherror = true
                };
            }

        }



        public async Task<RoleResponseDto> GetAllRolesAsync()
        {
            var role = await _dbContext.Roles
            .Select(x => new RoleDto()
            {
                Name = x.Name,
            }).ToListAsync();
            if (role != null)
            {
                return new RoleResponseDto
                {
                    Success = true,
                    Message = "Role Retrieved Succesfully",
                    Data = role
                };
            }
            else
            {
                return new RoleResponseDto
                {
                    Success = false,
                    Message = "Role Retrieval Failed",
                    Hasherror = true
                };
            }
        }

        public async Task<RoleResponseDto> GetRoleByIdAsync(int Id)
        {
            var role = await _dbContext.Roles
                .Where(x => x.Id == Id)
                .Select(x => new RoleDto()
                {
                    Name = x.Name,
                }).ToListAsync();
            if (role != null)
            {
                return new RoleResponseDto
                {
                    Success = true,
                    Message = "Role Retrieval Failed",
                    Hasherror = true
                };
            }
            else
            {

                return new RoleResponseDto
                {
                    Success = false,
                    Message = "Role Retrieval Failed",
                    Hasherror = true
                };
            }
        }

        public async Task<BaseResponse> UpdateRole(int Id, UpdateRole request)
        {
            var role = _dbContext.Roles.FirstOrDefault(x => x.Id == Id);
            if (role != null)
            {
                // role.Id = request.Id;
                role.Name = request.Name;
            };
            _dbContext.Roles.Update(role);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = "Role Updated Succesfully"
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Role Updated Failed",
                    Hasherror = true
                };
            }
        }



    }
}



