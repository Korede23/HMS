﻿using HMS.Model.Entity;

namespace HMS.Dto.RequestModel
{
    public class CreateOrder
    {
        public int CustomerId { get; set; }
        public Customer CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
