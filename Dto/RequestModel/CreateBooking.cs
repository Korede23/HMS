using HMS.Model.Entity;
using HMS.Model.Entity.Enum;

namespace HMS.Dto.RequestModel
{
    public class CreateBooking
    {
        //public int Id { get; set; }
        public int Duration { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime Checkout { get; set; }
        public RoomStatus Status { get; set; }
        public decimal TotalCost { get; set; }
        public ICollection<Room> rooms { get; set; } = new List<Room>();


       
    }

    
}
