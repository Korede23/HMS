using HMS.Dto.ResponseModel;
using HMS.Model.Entity;
using HMS.Model.Entity.Enum;

namespace HMS.Dto.BookingDto
{
    public class BookingDto
    {
        // public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime Checkout { get; set; }
        public RoomStatus Status { get; set; } = RoomStatus.Pending;
        public decimal TotalCost { get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();

    }

    public class BookingResponseDto : BaseResponse
    {
        public List<BookingDto> Data { get; set; }

    }
}
