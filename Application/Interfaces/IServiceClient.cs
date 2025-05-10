using Application.DTO;

namespace Application.Interfaces
{
    public interface IServiceClient
    {
        public Task<ResponseDTO<ClientDTO?>> CreateClient(ClientDTO clientDto);
        public Task<ResponseDTO<ClientDTO?>> DeleteClient(string cuit);
        public Task<List<ClientDTO>> GetAllClientDtos();
        public Task<ResponseDTO<ClientDTO?>> GetClientByCUIT(string cuit);
        public Task<ResponseDTO<ClientDTO?>> UpdateClient(ClientDTO clientDto);

    }
}
