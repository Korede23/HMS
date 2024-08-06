using HMS.Dto;
using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;
using HMS.Implementation.Interface;
using HMS.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HMS.Implementation.Services
{
    public class RoomService : IRoomService
    {
        private readonly ApplicationDbContext _dbContext;

        public RoomService(ApplicationDbContext dbContext)
        {

            _dbContext = dbContext;
        }
        public async Task<BaseResponse<Guid>> CreateRoom(CreateRoom request)
        {


            if (request != null)
            {
                // Check if the room already exists
                var existingRoom = _dbContext.Rooms.FirstOrDefault(x =>
                    x.Id == request.Id);

                if (existingRoom != null)
                {
                    // Room already exists
                    return new BaseResponse<Guid>
                    {
                        Success = true,
                        Message = $"Room {request.RoomName} already exists.",
                        Hasherror = true
                    };

                }

                //create a new one
                var room = new Room
                {
                    RoomName = request.RoomName,
                    Availability = request.Availability,
                    RoomNumber = request.RoomNumber,
                    RoomRate = request.RoomRate,
                    RoomStatus = request.RoomStatus,
                    BedType = request.BedType,
                    RoomType = request.RoomType,
                    MaxOccupancy = request.MaxOccupancy
                };

                await _dbContext.Rooms.AddAsync(room);
                _dbContext.SaveChanges();
            }
            return new BaseResponse<Guid>
            {
                Success = true,
                Message = $"Room {request.RoomName} Created Successfully"

            };



        }


        public async Task<BaseResponse<Guid>> DeleteRoomAsync(int Id)
        {
            var room = await _dbContext.Rooms.FirstOrDefaultAsync();
            if (room != null)
            {
                _dbContext.Rooms.Remove(room);
            }
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse<Guid>
                {
                    Success = true,
                    Message = $"Room  Number {Id} has been deleted succesfully "
                };
            }
            return new BaseResponse<Guid>
            {
                Success = false,
                Message = $"Failed to delete room with {Id}.The room may not exist or there was an error in the deletion process."
            };
        }

        public async Task<BaseResponse<IList<RoomDto>>> GetAllRoomsCreatedAsync()
        {
            var rooms = await _dbContext.Rooms
             .Select(x => new RoomDto()
             {
                 Id = x.Id, 
                 RoomName = x.RoomName,
                 RoomNumber = x.RoomNumber,
                 Availability = x.Availability,
                 RoomRate = x.RoomRate,
                 RoomStatus = x.RoomStatus,
                 BedType = x.BedType,
                 RoomType = x.RoomType,
                 MaxOccupancy = x.MaxOccupancy,
             }).ToListAsync();

            if (rooms != null)
            {
                return new BaseResponse<IList<RoomDto>>
                {
                    Success = true,
                    Message = "Rooms Succesfully Retrieved",
                    Data = rooms
                };
            }
            else
            {
                return new BaseResponse<IList<RoomDto>>
                {
                    Success = false,
                    Message = "Rooms Retrieval failed",
                    Hasherror = true

                };
            }


        }




        public async Task<BaseResponse<RoomDto>> GetRoomsByIdAsync(int Id)
        {

            var rooms = await _dbContext.Rooms
             .Where(x => x.Id == Id)
             .Select(x => new RoomDto()
             {
                 Id = x.Id,
                 RoomName = x.RoomName,
                 RoomNumber = x.RoomNumber,
                 Availability = x.Availability,
                 RoomRate = x.RoomRate,
                 RoomStatus = x.RoomStatus,
                 BedType = x.BedType,
                 RoomType = x.RoomType,
                 MaxOccupancy = x.MaxOccupancy,
             }).ToListAsync();
            if (rooms != null)
            {
                return new BaseResponse<RoomDto>
                {
                    Success = true,
                    Message = "Room  Retrieved succesfully",


                };
            }
            else
            {
                return new BaseResponse<RoomDto>
                {
                    Success = false,
                    Message = "Room  Retrieval Failed"
                };
            }

        }



        public async Task<BaseResponse<RoomDto>> UpdateRoom(int Id, UpdateRoom request)
        {
            var room = _dbContext.Rooms.FirstOrDefault(x => x.Id == Id);
            if (room == null)
            {
                return new BaseResponse<RoomDto>
                {
                    Success = false,
                    Message = $"Room {request.Id} Update failed",
                    Hasherror = true
                };
            }
            room.RoomNumber = request.RoomNumber;
            room.RoomName = request.RoomName;
            room.RoomRate = request.RoomRate;
            room.RoomStatus = request.RoomStatus;
            room.BedType = request.BedType;
            room.RoomType = request.RoomType;
            room.MaxOccupancy = request.MaxOccupancy;
            room.RoomStatus = request.RoomStatus;
            room.Id = request.Id;
            _dbContext.Rooms.Update(room);
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse<RoomDto>
                {
                    Success = true,
                    Message = $"Room {request.Id} Updated Succesfully"
                };

            }
            return new BaseResponse<RoomDto>
            {
                Success = false,
                Message = $"Room {request.Id} Update failed",
                Hasherror = true
            };
        }



        public async Task<List<SelectAmenity>> GetAmenity()
        {
            var amenities = await _dbContext.Amenities.ToListAsync();
            var result = new List<SelectAmenity>();
            if (amenities.Count > 0)
            {
                result = amenities.Select(x => new SelectAmenity
                {
                    Id = x.Id,
                    AmenityName = x.AmenityName
                }).ToList();
            }
            return result;
        }
    }
}


