using HMS.Dto;
using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;

namespace HMS.Implementation.Interface
{
    public interface IProductServices
    {
        Task<BaseResponse> CreateProduct(CreateProduct request);
        Task<BaseResponse> DeleteProductAsync(int Id);
        Task<ProductResponseDto> GetAllProductAsync();
        Task<ProductResponseDto> GetAllProductsByIdAsync(int Id);
        Task<BaseResponse> UpdateProduct(int Id, UpdateProduct request);
    }
}
