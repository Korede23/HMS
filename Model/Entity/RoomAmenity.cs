﻿namespace HMS.Model.Entity
{
    public class RoomAmenity : BaseEntity
    {
        public int RoomId { get; set; }
        public int AmenityId { get; set; }
        public Room Room { get; set; }
        public Amenity AmenityName { get; set; }
    }
}
