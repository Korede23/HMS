using HMS.Dto;
using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;

namespace HMS.Implementation.Interface
{
    public interface IProductServices
    {
        Task<BaseResponse<Guid>> CreateProduct(CreateProduct request);
        Task<BaseResponse<Guid>> DeleteProductAsync(int Id);
        Task<BaseResponse<ProductDto>> GetAllProductsByIdAsync(int Id);
        Task<BaseResponse<IList<ProductDto>>> GetAllProductAsync();
        Task<BaseResponse<ProductDto>> UpdateProduct(int id, UpdateProduct request);
    }
}
