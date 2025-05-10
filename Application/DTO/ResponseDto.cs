namespace Application.DTO
{
    public class ResponseDTO<ClientDTO>
    {
        public ClientDTO? Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }

}
