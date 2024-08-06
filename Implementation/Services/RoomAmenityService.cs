//using HMS.Dto.RequestModel;
//using HMS.Dto.ResponseModel;
//using HMS.Model.Entity;
//using Microsoft.EntityFrameworkCore;

//namespace HMS.Implementation.Services
//{
//    public class RoomAmenityService
//    {
//        private readonly ApplicationDbContext _dbContext;

//        public RoomAmenityService(ApplicationDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task<BaseResponse> CreateRoomAmenity(CreateRoomAmenity request)
//        {
//            if (request != null)
//            {
//                var roomAmenity = new RoomAmenity
//                {
//                    AmenityId = request.AmenityId,
//                    RoomId = request.RoomId,
//                    AmenityName = request.Amenity,
//                    Room = request.Room
//                };
//                _dbContext.RoomAmenities.Add(roomAmenity);
//            }
            
//            if (await _dbContext.SaveChangesAsync() > 0)
//            {
//                return new BaseResponse
//                {
//                    Success = true,
//                    Message = "Room Amenity Created Succesfully"
//                };
//            }
//            else
//            {
//                return new BaseResponse
//                {

//                };
//            }

//        }


//        public async Task<BaseResponse> DeleteRoomAmenity(int Id)
//        {
//            var roomAmenity = await _dbContext.RoomAmenities.FirstOrDefaultAsync(x => x.Id == Id);
//            if (roomAmenity != null)
//            {
//                _dbContext.RoomAmenities.Remove(roomAmenity);
//            }
//            if (await _dbContext.SaveChangesAsync() > 0)
//            {
//                return new BaseResponse
//                {
//                    Success = true,
//                    Message = "Room Amenity has been deleted  "
//                };
//            }
//            else
//            {
//                return new BaseResponse
//                {
//                    Success = false,
//                    Message = "Failed  "
//                };
//            }
//        }

//    }
//}
