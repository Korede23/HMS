namespace HMS.Dto.ResponseModel
{


    public class RoomResponseModel : BaseResponse
    {
        public RoomDto Data { get; set; }
    }

    public class RoomsResponseModel : BaseResponse
    {
        public List<RoomDto> Data { get; set; }
    }



}
