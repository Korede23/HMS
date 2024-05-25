using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;

namespace HMS.Implementation.Interface
{
    public interface IPackageServices
    {
        Task<BaseResponse> CreatePackage(CreatePackage request);
        Task<BaseResponse> DeletePackageAsync(int Id);
        Task<PackageResponseDto> GetAllPackagesAsync();
        Task<PackageResponseDto> GetAllPackagesByIdAsync(int Id);
        Task<BaseResponse> UpdatePackage(int Id, UpdatePackage request);
    }
}
