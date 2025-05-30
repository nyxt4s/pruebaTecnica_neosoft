namespace MantenedorApi.Models.Response
{
    public class ResponseUser
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public User? User { get; set; }
    }
}
