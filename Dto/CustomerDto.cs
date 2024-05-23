using HMS.Dto.ResponseModel;
using HMS.Model.Entity.Enum;

namespace HMS.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }

    }
    public class CustomerResponseDto : BaseResponse
    {
        public List<CustomerDto> Data { get; set; }
    }
}
