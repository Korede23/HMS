using HMS.Model.Entity.Enum;

namespace HMS.Dto.RequestModel
{
    public class CreateRoom
    {
        // public int Id { get; set; }
        public RoomName RoomName { get; set; }
        public int RoomNumber { get; set; }
        public RoomType RoomType { get; set; }
        public BedType BedType { get; set; }
        public int MaxOccupancy { get; set; }
        public decimal RoomRate { get; set; }
        public RoomStatus RoomStatus { get; set; }
        public SelectAmenity Name { get; set; }

        public bool Availability { get; set; }


    }
}
