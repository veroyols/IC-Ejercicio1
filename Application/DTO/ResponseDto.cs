namespace Application.DTO
{
    public class ResponseDTO
    {
        public ClientDTO? ClientDto { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }

}
