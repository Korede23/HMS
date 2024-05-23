﻿using HMS.Model.Entity;

namespace HMS.Dto.ResponseModel
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
    public class OrderResponseDto : BaseResponse
    {
        public List<OrderDto> Data { get; set; }
    }
}
