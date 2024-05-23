using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;

namespace HMS.Implementation.Interface
{
    public interface IOrderServices
    {
        Task<BaseResponse> CreateOrder(CreateOrder request);
        Task<BaseResponse> DeleteOrderAsync(int Id);
        Task<OrderResponseDto> GetOrderByIdAsync(int Id);
        Task<OrderResponseDto> GetAllOrderAsync();
        Task<BaseResponse> UpdateOrder(int Id, UpdateOrder request);
    }
}
