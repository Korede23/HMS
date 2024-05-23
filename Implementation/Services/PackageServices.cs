using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;
using HMS.Implementation.Interface;
using HMS.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace HMS.Implementation.Services
{
    public class PackageServices : IPackageServices
    {
        private readonly ApplicationDbContext _dbContext;

        public PackageServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<BaseResponse> CreatePackage(CreatePackage request)
        {
            if (request != null)
            {
                var items = new Package
                {
                    Name = request.Name,
                    Items = request.Items,
                    Price = request.Price,
                };
                _dbContext.Packages.Add(items);
            }

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = "Package Created Succesfully"
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Fail To Create Package",
                    Hasherror = true
                };
            }


        }

        public async Task<BaseResponse> DeletePackageAsync(int Id)
        {
            var item = await _dbContext.Packages.FirstOrDefaultAsync(x => x.Id == Id);

            if (item != null)
            {
                _dbContext.Packages.Remove(item);
            }
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = "Package has been deleted Succesfully"
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Failed to delete This Package",
                    Hasherror = true
                };
            }
        }

        public async Task<PackageResponseDto> GetAllPackagesByIdAsync(int Id)
        {

            var item = await _dbContext.Packages
                .Where(x => x.Id == Id)
                .Select(x => new PackageDto
                {
                    Items = x.Items,
                    Name = x.Name,
                    Price = x.Price,
                }).ToListAsync();
            if (item != null)
            {
                return new PackageResponseDto
                {
                    Success = true,
                    Message = "Packages Retrieved Succesfully",
                    Data = item
                };
            }
            else
            {
                return new PackageResponseDto
                {
                    Success = false,
                    Message = "Retrieved Failed",
                    Hasherror = true
                };
            }

        }

        public async Task<PackageResponseDto> GetAllPackagesAsync()
        {

            var item = await _dbContext.Packages
                .Select(x => new PackageDto
                {
                    Items = x.Items,
                    Name = x.Name,
                    Price = x.Price,
                }).ToListAsync();
            if (item != null)
            {
                return new PackageResponseDto
                {
                    Success = true,
                    Message = "Packages Retrieved Succesfully",
                    Data = item
                };
            }
            else
            {
                return new PackageResponseDto
                {
                    Success = false,
                    Message = "Retrieved Failed",
                    Hasherror = true
                };
            }
        }


        public async Task<BaseResponse> UpdatePackage(int Id , UpdatePackage request)
        {
            var item = await _dbContext.Packages.FirstOrDefaultAsync(x => x.Id == Id);
            if (item != null)
            {
                item.Id = request.Id;
                item.Name = request.Name;
                item.Price = request.Price;
                item.Items = request.Items;
            }
            _dbContext.Packages.Add(item);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = $"Package with ID {Id} Updated successfully."
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Failed to Update package ,there was an error in the updating process.",
                    Hasherror = true
                };
            }
        }
    }
}
