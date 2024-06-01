using HMS.Dto;
using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;
using System.Threading.Tasks;

namespace HMS.Implementation.Interface
{
    public interface IRoomService
    {
         Task<BaseResponse> CreateRoom(CreateRoom request);
        Task<BaseResponse> DeleteRoomAsync(int Id);
        Task<BaseResponse> UpdateRoom(int Id, UpdateRoom request);
        Task<RoomResponseDto> GetRoomsByIdAsync(int Id);
        Task<RoomResponseDto> GetAllRoomsCreatedAsync();
        Task<List<SelectAmenity>> GetAmenity();



    }
}