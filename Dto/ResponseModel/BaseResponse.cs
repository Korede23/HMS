namespace HMS.Dto.ResponseModel
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public bool Hasherror { get; set; } = false;
    }

   
}
