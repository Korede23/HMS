using HMS.Model.Entity;
using HMS.Model.Entity.Enum;

namespace HMS.Dto.RequestModel
{
    public class CreateBooking
    {
        //public int Id { get; set; }
        //public DateTime CheckIn { get; set; }
        //public DateTime Checkout { get; set; }
        public RoomStatus Status { get; set; }
        public decimal TotalCost { get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
        public class Room
        {
            public int RoomId { get; set; }
            public RoomType RoomType { get; set; }
        }
    }
    
}
