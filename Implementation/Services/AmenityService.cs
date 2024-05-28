using HMS.Dto;
using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;
using HMS.Implementation.Interface;
using HMS.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace HMS.Implementation.Services
{
    public class AmenityService : IAmenityService
    {
        private readonly ApplicationDbContext _dbContext;

        public AmenityService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseResponse> CreateAmenity(CreateAmenityRequestModel request)
        {
            if (request != null)
            {
                var roomAmenity = new Amenity
                {
                    AmenityName = request.AmenityName,
                    AmenityType = request.AmenityType,
                };
                _dbContext.Amenities.Add(roomAmenity);
            }

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = "Successful"
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Failed"
                };
            }
        }


        public async Task<BaseResponse> DeleteAmenity(int Id)
        {
            var amenity = await _dbContext.Amenities.FirstOrDefaultAsync(x => x.Id == Id);
            if (amenity != null)
            {
                _dbContext.Amenities.Remove(amenity);
            }
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = "Amenity Deleted Successful"
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Failed"
                };
            }
        }

        public async Task<AmenityResponseDto> GetAmenityBYId(int Id)
        {
            var amenity = await _dbContext.Amenities
            .Where(x => x.Id == Id)
            .Select(x => new AmenityDto
            {
                AmenityName = x.AmenityName,
                AmenityType = x.AmenityType,

            }).ToListAsync();
            if (amenity != null)
            {
                return new AmenityResponseDto
                {
                    Success = true,
                    Message = "Successful"
                };
            }
            else
            {
                return new AmenityResponseDto
                {
                    Success = false,
                    Message = "Successful"
                };
            }



        }

        public async Task<AmenityResponseDto> GetAllAmenity()
        {
            var amenity = await _dbContext.Amenities
            .Select(x => new AmenityDto
            {
                AmenityName = x.AmenityName,
                AmenityType = x.AmenityType,

            }).ToListAsync();
            if (amenity != null)
            {
                return new AmenityResponseDto
                {
                    Success = true,
                    Message = "Successful"
                };
            }
            else
            {
                return new AmenityResponseDto
                {
                    Success = false,
                    Message = "Successful"
                };
            }
        }

        public async Task<BaseResponse> UpdateAmenity (int Id , UpdateAmenity request)
        {
            var amenity = await _dbContext.Amenities.FirstOrDefaultAsync(x => x.Id == Id);
            if (amenity != null)
            {
                amenity.AmenityName = request.AmenityName;
                amenity.AmenityType = request.AmenityType;
            }
            _dbContext.Amenities.Add(amenity);
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = "Updated Successful"
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Update Failed"
                };
            }
        }
    }
}

