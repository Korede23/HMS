using HMS.Dto;
using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;
using HMS.Implementation.Interface;
using HMS.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace HMS.Implementation.Services
{
    public class UserService : IUserServices
    {
        private readonly ApplicationDbContext _dbContext;
        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseResponse> CreateUser(CreateUser request)
        {

            if (request != null)
            {
                var user = new User()
                {
                    UserName = request.UserName,
                    Address = request.Address,
                    Age = request.Age,
                    CreatedTime = DateTime.Now,
                    Email = request.Email,
                    Gender = request.Gender,
                    Password = request.Password,
                    PhoneNumber = request.PhoneNumber,

                };
                _dbContext.Users.Add(user);


                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse

                    {
                        Success = true,
                        Message = "User Created Successfully"
                    };
                }
            }
            return new BaseResponse

            {
                Success = false,
                Message = "User Created failed"
            };

        }



        public async Task<BaseResponse> DeleteUserAsync(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
            }

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = "User deleted succesfully",


                };
            }

            else
            {
                return new BaseResponse

                {
                    Success = false,
                    Message = "Delete Failed, unable to process the deletion of User at this time"
                };
            }
        }





        //public bool DeleteUser(int id)
        //{
        //    var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
        //    if (user != null)
        //    {
        //        _dbContext.Users.Remove(user);
        //    }
        //    return _dbContext.SaveChanges() > 0 ? true : false;
        //}

        public async Task<UserResponseDto> GetUserByIdAsync(int Id)
        {
            try
            {  
                
                var user = await _dbContext.Users
                .Where(x => x.Id == Id)
                .Select(x => new UserDto()
                {
                    Address = x.Address,
                    Age = x.Age,
                    Email = x.Email,
                    Gender = x.Gender,
                    Name = x.Name,
                    Password = x.Password,
                    PhoneNumber = x.PhoneNumber,
                    UserId = Id,
                    UserName = x.UserName,
                }).ToListAsync();
                if (user != null)
                {
                    return new UserResponseDto
                    {
                        Success = true,
                        Message = "User retrieved successfully",
                       Data = user
                       
                    };
                }
                else
                {
                    return new UserResponseDto
                    {
                        Success = false,
                        Message = "User not found"
                    };
                }

            }
            catch (Exception ex)
            {
                return new UserResponseDto
                {
                    Success = false,
                    Message = "Failed to retrieve user ",
                    Hasherror = true
                };

            }

        }




        public async Task<UserResponseDto> GetAllUserAsync()
        {
            try
            {
                var user = await _dbContext.Users
               .Select(x => new UserDto
               {
                   Address = x.Address,
                   Age = x.Age,
                   Email = x.Email,
                   Gender = x.Gender,
                   Name = x.Name,
                   Password = x.Password,
                   PhoneNumber = x.PhoneNumber,
                   UserId = x.Id,
                   UserName = x.UserName,
               }).ToListAsync();
                return new UserResponseDto
                {
                    Success = true,
                    Message = "Users retrieved successfully",
                    Data = user
                };
            }
            catch (Exception ex)
            {
                return new UserResponseDto
                {
                    Success = false,
                    Message = "Failed to retrieve users"
                };
            }

        }




        public async Task<BaseResponse> UpdateUser(int Id, UpdateUser request)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == Id);
            if (user != null)
            {
                user.Name = request.Name;
                user.Password = request.Password;
                user.PhoneNumber = request.PhoneNumber;
                user.UserName = request.UserName;
                user.Password = request.Password;
                user.PhoneNumber = request.PhoneNumber;
                user.Email = request.Email;
                user.Address = request.Address;
                user.Age = request.Age;

            };
            _dbContext.Users.Update(user);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = "User Updated succesfully"
                };
            }
            return new BaseResponse
            {
                Success = false,
                Message = "Update Failed"
            };
        }
    }
}



