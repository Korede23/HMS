using HMS.Dto.ResponseModel;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        internal object Select(Func<object, SelectListItem> value)
        {
            throw new NotImplementedException();
        }
    }
}
