﻿using HMS.Model.Entity;

namespace HMS.Dto.RequestModel
{
    public class CreateRoomAmenity
    {
        public int RoomId { get; set; }
        public int AmenityId { get; set; }
        public Room Room { get; set; }
        public Amenity Amenity { get; set; }
    }
}