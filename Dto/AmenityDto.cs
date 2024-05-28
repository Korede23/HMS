using HMS.Dto.ResponseModel;

namespace HMS.Dto
{
    public class AmenityDto
    {
        public string AmenityName { get; set; }
        public string  AmenityType { get; set; }
    }

    public class AmenityResponseDto : BaseResponse
    {
        public List<AmenityDto> Data { get; set; }
    }
}
