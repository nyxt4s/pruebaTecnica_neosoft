namespace MantenedorApi.Models.Response
{
    public class ResponseMessage<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
    }
}
