using HMS.Dto.ResponseModel;

namespace HMS.Dto.RequestModel
{
    public class PackageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Items { get; set; }
        public double Price { get; set; }
    }
    public class PackageResponseDto : BaseResponse
    {
        public List<PackageDto> Data { get; set; }
    }
}
