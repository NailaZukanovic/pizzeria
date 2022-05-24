namespace Pizzeria.API.Dto
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
    }
}
