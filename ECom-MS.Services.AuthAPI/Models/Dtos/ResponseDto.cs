namespace ECom_MS.Services.CouponAPI.Models.Dtos
{
    public class ResponseDto
    {
        public object? Result { get; set; }
        public bool IsError { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
