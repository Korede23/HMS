using HMS.Dto.RequestModel;
using HMS.Model.Entity.Enum;

namespace HMS.Model.Entity
{
    public class Booking : BaseEntity
    {
        public DateTime CheckIn { get; set; }
        public DateTime Checkout { get; set; }
        public RoomStatus Status { get; set; }
        public decimal TotalCost { get; set; }
    }
}
