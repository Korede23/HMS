using HMS.Dto.ResponseModel;

namespace HMS.Dto
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class RoleResponseDto : BaseResponse
    {
        public List<RoleDto> Data { get; set; }

    }
}
