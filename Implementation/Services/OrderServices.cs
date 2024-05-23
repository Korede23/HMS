using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;
using HMS.Implementation.Interface;
using HMS.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace HMS.Implementation.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseResponse> CreateOrder(CreateOrder request)
        {
            try
            {
                if (request != null)
                {
                    var order = new Order
                    {
                        CustomerId = request.CustomerId,
                        CustomerName = request.CustomerName,
                        OrderDate = request.OrderDate,
                        TotalAmount = request.TotalAmount,

                    };
                    _dbContext.Orders.Add(order);
                }

                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse
                    {
                        Success = true,
                        Message = $"Order By {request.CustomerName} has been Created Succesfully"
                    };
                }
                else
                {
                    return new BaseResponse
                    {
                        Success = false,
                        Message = "Order Failed"

                    };
                }


            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Order failed ,Unable to create Order",
                    Hasherror = true
                };
            }
        }


        public async Task<BaseResponse> DeleteOrderAsync(int Id)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == Id);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
            }
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = $"Order Has been deleted succesfully",
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = " Failed to delete Order,The order may not exist or there was an error in the deletion process.",
                    Hasherror = true
                };
            }

        }

        public async Task<OrderResponseDto> GetOrderById(int Id)
        {
            var order = await _dbContext.Orders
            .Where(x => x.Id == Id)
            .Select(x => new OrderDto
            {
                CustomerName = x.CustomerName,
                CustomerId = x.CustomerId,
                OrderDate = x.OrderDate,
                TotalAmount = x.TotalAmount
            }).ToListAsync();

            if (order != null)
            {
                return new OrderResponseDto
                {
                    Success = true,
                    Message = "Order Retrieved Succesfully",
                    Data = order
                };
            }
            else
            {
                return new OrderResponseDto
                {
                    Success = false,
                    Message = "Failed to retrieve order , there was an error in the retrieval process",
                    Hasherror = true
                };
            }

        }



        public async Task<OrderResponseDto> GetAllOrderAsync()
        {
            var order = await _dbContext.Orders
           .Select(x => new OrderDto
           {
               CustomerName = x.CustomerName,
               CustomerId = x.CustomerId,
               OrderDate = x.OrderDate,
               TotalAmount = x.TotalAmount
           }).ToListAsync();

            if (order != null)
            {
                return new OrderResponseDto
                {
                    Success = true,
                    Message = "Order Retrieved Succesfully",
                    Data = order
                };
            }
            else
            {
                return new OrderResponseDto
                {
                    Success = false,
                    Message = "Failed to retrieve order , there was an error in the retrieval process",
                    Hasherror = true
                };
            }

        }


        public async Task<BaseResponse> UpdateOrder(int Id, UpdateOrder request)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == Id);
            if (order != null)
            {
                order.CustomerId = request.CustomerId;
                order.OrderDate = request.OrderDate;
                order.TotalAmount = request.TotalAmount;
                order.CustomerName = request.CustomerName;
            }
            _dbContext.Orders.Add(order);
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = $"Order with ID {Id} Updated successfully."
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = $"Failed to Update order {request.CustomerName} ,there was an error in the updating process.",
                    Hasherror = true
                };
            }
        }
    }
}
