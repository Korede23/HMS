using HMS.Dto.RequestModel;
using HMS.Model.Entity.Enum;

namespace HMS.Model.Entity
{
    public class Booking : BaseEntity
    {
        
        public int RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime Checkout { get; set; }
        public RoomStatus Status { get; set; }
        public int Duration { get; set; }
        public decimal TotalCost { get; set; }

     
    }
}
