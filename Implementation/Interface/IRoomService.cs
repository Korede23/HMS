using HMS.Dto;
using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;
using System.Threading.Tasks;

namespace HMS.Implementation.Interface
{
    public interface IRoomService
    {
        Task<BaseResponse<Guid>> CreateRoom(CreateRoom request);
        Task<BaseResponse<Guid>> DeleteRoomAsync(int Id);
        Task<BaseResponse<IList<RoomDto>>> GetAllRoomsCreatedAsync();
        Task<BaseResponse<RoomDto>> GetRoomsByIdAsync(int Id);
        Task<BaseResponse<RoomDto>> UpdateRoom(int Id, UpdateRoom request);
        Task<List<SelectAmenity>> GetAmenity();



    }
}