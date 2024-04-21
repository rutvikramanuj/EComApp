namespace EComApp.Web.Models.Dtos
{
    public class ResponseDto
    {
        public object? result { get; set; }
        public bool isError { get; set; }
        public bool isSuccess { get; set; }
        public string message { get; set; }
    }
}
