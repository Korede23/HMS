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


        public async Task<BaseResponse<Guid>> CreateProduct(CreateProduct request)
        {
            try
            {
                if (request != null)
                {
                    var items = new Product
                    {
                        Name = request.Name,
                        Price = request.Price
                    };
                    _dbContext.Products.Add(items);
                }

                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse<Guid>
                    {
                        Success = true,
                        Message = "Product Created Successfully",

                    };
                }
                else
                {
                    return new BaseResponse<Guid>
                    {
                        Success = false,
                        Message = "Fail To Create Product",
                        Hasherror = true
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<Guid>
                {
                    Success = false,
                    Message = "Fail To Create Product",
                    Hasherror = true
                };
            }


        }



        public async Task<BaseResponse<Guid>> DeleteProductAsync(int Id)
        {
            try
            {
                var item = await _dbContext.Products.FirstOrDefaultAsync();

                if (item != null)
                {
                    _dbContext.Products.Remove(item);
                }
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse<Guid>
                    {
                        Success = true,
                        Message = "Product has been deleted Succesfully"
                    };
                }
                else
                {
                    return new BaseResponse<Guid>
                    {
                        Success = false,
                        Message = "Failed to delete This Product",
                        Hasherror = true
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<Guid>
                {
                    Success = false,
                    Message = "Failed to delete This Product",
                    Hasherror = true
                };
            }

        }

        public async Task<BaseResponse<ProductDto>> GetAllProductsByIdAsync(int Id)
        {

            var item = await _dbContext.Products
                .Where(x => x.Id == Id)
                .Select(x => new ProductDto
                {
                    Name = x.Name,
                    Price = x.Price,
                }).FirstOrDefaultAsync();
            if (item != null)
            {
                return new BaseResponse<ProductDto>
                {
                    Success = true,
                    Message = "Products Retrieved Succesfully",
                    Data = item
                };
            }
            else
            {
                return new BaseResponse<ProductDto>
                {
                    Success = false,
                    Message = "Retrieved Failed",
                    Hasherror = true
                };
            }

        }


       
        public async Task<BaseResponse<IList<ProductDto>>> GetAllProductAsync()
        {

            var item = await _dbContext.Products
                .Select(x => new ProductDto
                {
                    Name = x.Name,
                    Price = x.Price,
                }).ToListAsync();
            if (item != null)
            {
                return new BaseResponse<IList<ProductDto>>
                {
                    Success = true,
                    Message = "Products Retrieved Succesfully",
                    Data = item
                };
            }
            else
            {
                return new BaseResponse<IList<ProductDto>>
                {
                    Success = false,
                    Message = "Retrieved Failed",
                    Hasherror = true
                };
            }
        }

        public async Task<BaseResponse<ProductDto>> UpdateProduct(int id, UpdateProduct request)
        {
            try
            {
                var item = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (item == null)
                {
                    return new BaseResponse<ProductDto>
                    {
                        Success = false,
                        Message = "Product not found.",
                        Hasherror = true
                    };
                }

                item.Name = request.Name;
                item.Price = request.Price;

                _dbContext.Products.Update(item);
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse<ProductDto>
                    {
                        Success = true,
                        Message = $"Product with ID {id} updated successfully."
                    };
                }
                else
                {
                    return new BaseResponse<ProductDto>
                    {
                        Success = false,
                        Message = "Failed to update product.",
                        Hasherror = true
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<ProductDto>
                {
                    Success = false,
                    Message = "An error occurred while updating the product.",
                    Hasherror = true
                };
            }
        }

    }
}
