using HMS.Dto.ResponseModel;

namespace HMS.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Items { get; set; }
        public double Price { get; set; }
    }
    public class ProductResponseDto : BaseResponse
    {
        public List<ProductDto> Data { get; set; }
    }
}
