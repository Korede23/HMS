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
        public async Task<BaseResponse> CreateRoom(CreateRoom request)
        {


            if (request != null)
            {
                // Check if the room already exists
                var existingRoom = _dbContext.Rooms.FirstOrDefault(x =>
                    x.RoomName == request.RoomName &&
                    x.RoomNumber == request.RoomNumber &&
                    x.RoomType == request.RoomType &&
                    x.RoomStatus == request.RoomStatus);

                if (existingRoom != null)
                {
                    // Room already exists
                    return new BaseResponse
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
            return new BaseResponse
            {
                Success = true,
                Message = $"Room {request.RoomName} Created Successfully"

            };
            
            

        }


        public async Task<BaseResponse> DeleteRoomAsync(int Id)
        {
            var room = await _dbContext.Rooms.FirstOrDefaultAsync();
            if (room != null)
            {
                _dbContext.Rooms.Remove(room);
            }
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = $"Room  Number {Id} has been deleted succesfully "
                };
            }
            return new BaseResponse
            {
                Success = false,
                Message = $"Failed to delete room with {Id}.The room may not exist or there was an error in the deletion process."
            };
        }

        public async Task<RoomResponseDto> GetAllRoomsCreatedAsync()
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
                return new RoomResponseDto
                {
                    Success = true,
                    Message = "Rooms Succesfully Retrieved",
                    Data = rooms
                };
            }
            else
            {
                return new RoomResponseDto
                {
                    Success = false,
                    Message = "Rooms Retrieval failed",
                    Hasherror = true

                };
            }


        }




        public async Task<RoomResponseDto> GetRoomsByIdAsync(int Id)
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
                return new RoomResponseDto
                {
                    Success = true,
                    Message = $"Room {Id} Retrieved succesfully",
                   

                };
            }
            else
            {
                return new RoomResponseDto
                {
                    Success = false,
                    Message = $"Room {Id} Retrieval Failed"
                };
            }

        }



        public async Task<BaseResponse> UpdateRoom(int Id, UpdateRoom request)
        {
            var room = _dbContext.Rooms.FirstOrDefault(x => x.Id == Id);
            if (room == null)
            {
                room.RoomNumber = request.RoomNumber;
                room.RoomName = request.RoomName;
                room.RoomRate = request.RoomRate;
                room.RoomStatus = request.RoomStatus;
                room.BedType = request.BedType;
                room.RoomType = request.RoomType;
                room.MaxOccupancy = request.MaxOccupancy;
                room.RoomStatus = request.RoomStatus;
                room.Id = request.Id;


            }
            _dbContext.Rooms.Update(room);
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = $"Room {request.Id} Updated Succesfully"
                };

            }
            return new BaseResponse
            {
                Success = false,
                Message = $"Room {request.Id} Update failed",
                Hasherror = true
            };
        }

    }
}


