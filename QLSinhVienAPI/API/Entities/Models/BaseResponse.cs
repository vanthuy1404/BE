namespace API.Models
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        public BaseResponse(T data, string message, bool success)
        {
            Data = data;
            Message = message;
            Success = success;
        }
    }
}