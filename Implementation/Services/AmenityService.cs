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

        public async Task<BaseResponse<Guid>> CreateAmenity(CreateAmenityRequestModel request)
        {
            try
            {
                if (request != null)
                {
                    var roomAmenity = new Amenity
                    {
                        AmenityName = request.AmenityName,
                    };
                    _dbContext.Amenities.Add(roomAmenity);
                }
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse<Guid>
                    {
                        Success = true,
                        Message = "Successful"
                    };
                }
                else
                {
                    return new BaseResponse<Guid>
                    {
                        Success = false,
                        Message = "Failed"
                    };
                }
            }
            catch (Exception ex)
            {

                return new BaseResponse<Guid>
                {
                    Success = false,
                    Message = "Failed"
                };

            }


        }


        public async Task<BaseResponse<Guid>> DeleteAmenity(int Id)
        {
            try
            {
                var amenity = await _dbContext.Amenities.FirstOrDefaultAsync();
                if (amenity != null)
                {
                    _dbContext.Amenities.Remove(amenity);
                }
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse<Guid>
                    {
                        Success = true,
                        Message = "Amenity Deleted Successful"
                    };
                }
                else
                {
                    return new BaseResponse<Guid>
                    {
                        Success = false,
                        Message = "Failed"
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<Guid>
                {
                    Success = false,
                    Message = "Failed"
                };
            }


        }


        public async Task<BaseResponse<AmenityDto>> GetAmenityById(int Id)
        {

            try
            {
                var amenity = await _dbContext.Amenities
                            .Where(x => x.Id == Id)
                            .Select(x => new AmenityDto
                            {
                                AmenityName = x.AmenityName,

                            }).FirstOrDefaultAsync();
                if (amenity != null)
                {
                    return new BaseResponse<AmenityDto>
                    {
                        Success = true,
                        Message = "Successful",
                        Data = amenity
                    };
                }
                else
                {
                    return new BaseResponse<AmenityDto>
                    {
                        Success = false,
                        Message = "Successful"
                    };
                }
            }
            catch (Exception ex)
            {

                return new BaseResponse<AmenityDto>
                {
                    Success = false,
                    Message = "Successful"
                };
            }



        }
        public async Task<BaseResponse<IList<AmenityDto>>> GetAllAmenity()
        {
            try
            {
                var amenity = await _dbContext.Amenities
                           .Select(x => new AmenityDto
                           {
                               AmenityName = x.AmenityName,

                           }).ToListAsync();
                if (amenity != null)
                {
                    return new BaseResponse<IList<AmenityDto>>
                    {
                        Success = true,
                        Message = "Successful"
                    };
                }
                else
                {
                    return new BaseResponse<IList<AmenityDto>>
                    {
                        Success = false,
                        Message = "Successful"
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<IList<AmenityDto>>
                {
                    Success = false,
                    Message = "Successful"
                };
            }


        }

        public async Task<BaseResponse<AmenityDto>> UpdateAmenity(int Id, UpdateAmenity request)
        {

            try
            {
                var amenity = await _dbContext.Amenities.FirstOrDefaultAsync(x => x.Id == Id);
                if (amenity == null)
                {
                    return new BaseResponse<AmenityDto>
                    {
                        Success = false,
                        Message = "Update Failed"
                    };
                }

                amenity.AmenityName = request.AmenityName;
                _dbContext.Amenities.Update(amenity);
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse<AmenityDto>
                    {
                        Success = true,
                        Message = "Updated Successful",
                        Data = new AmenityDto
                        {
                            AmenityName = request.AmenityName,
                        }

                    };
                }
                else
                {
                    return new BaseResponse<AmenityDto>
                    {
                        Success = false,
                        Message = "Update Failed"
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<AmenityDto>
                {
                    Success = false,
                    Message = "Update Failed"
                };
            }


        }
    }
}

