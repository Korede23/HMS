using HMS.Dto;
using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;

namespace HMS.Implementation.Interface
{
    public interface ICustomerServices
    {
        Task<BaseResponse> CreateCustomer(CreateCustomer request);
        Task<BaseResponse> DeleteCustomerAsync(int Id);
        Task<CustomerResponseDto> GetCustomerByIdAsync(int Id);
        Task<CustomerResponseDto> GetAllCustomerCreatedAsync();
        Task<BaseResponse> UpdateCustomer(int Id, UpdateCustomer request);
    }
}
