using HMS.Dto;
using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;
using HMS.Implementation.Interface;
using HMS.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace HMS.Implementation.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<BaseResponse> CreateProduct(CreateProduct request)
        {
            if (request != null)
            {
                var items = new Product
                {
                    Name = request.Name,
                    Items = request.Items,
                    Price = request.Price,
                };
                _dbContext.Products.Add(items);
            }

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = "Product Created Succesfully"
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Fail To Create Product",
                    Hasherror = true
                };
            }


        }

        public async Task<BaseResponse> DeleteProductAsync(int Id)
        {
            var item = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == Id);

            if (item != null)
            {
                _dbContext.Products.Remove(item);
            }
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = "Product has been deleted Succesfully"
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Failed to delete This Product",
                    Hasherror = true
                };
            }
        }

        public async Task<ProductResponseDto> GetAllProductsByIdAsync(int Id)
        {

            var item = await _dbContext.Products
                .Where(x => x.Id == Id)
                .Select(x => new ProductDto
                {
                    Items = x.Items,
                    Name = x.Name,
                    Price = x.Price,
                }).ToListAsync();
            if (item != null)
            {
                return new ProductResponseDto
                {
                    Success = true,
                    Message = "Products Retrieved Succesfully",
                    Data = item
                };
            }
            else
            {
                return new ProductResponseDto
                {
                    Success = false,
                    Message = "Retrieved Failed",
                    Hasherror = true
                };
            }

        }

        public async Task<ProductResponseDto> GetAllProductAsync()
        {

            var item = await _dbContext.Products
                .Select(x => new ProductDto
                {
                    Items = x.Items,
                    Name = x.Name,
                    Price = x.Price,
                }).ToListAsync();
            if (item != null)
            {
                return new ProductResponseDto
                {
                    Success = true,
                    Message = "Products Retrieved Succesfully",
                    Data = item
                };
            }
            else
            {
                return new ProductResponseDto
                {
                    Success = false,
                    Message = "Retrieved Failed",
                    Hasherror = true
                };
            }
        }


        public async Task<BaseResponse> UpdateProduct(int Id , UpdateProduct request)
        {
            var item = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == Id);
            if (item != null)
            {
                item.Id = request.Id;
                item.Name = request.Name;
                item.Price = request.Price;
                item.Items = request.Items;
            }
            _dbContext.Products.Add(item);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = $"Product with ID {Id} Updated successfully."
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Failed to Update Product ,there was an error in the updating process.",
                    Hasherror = true
                };
            }
        }
    }
}
