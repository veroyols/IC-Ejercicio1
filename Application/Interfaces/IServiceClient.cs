using Application.DTO;

namespace Application.Interfaces
{
    public interface IServiceClient
    {
        public Task<ResponseDTO> CreateClient(ClientDTO client);
        public Task<ResponseDTO> DeleteClient(string cuit);
        public Task<List<ClientDTO>> GetAllClientDtos();
        public Task<ClientDTO> GetClientByCUIT(string cuit);
        public Task<ResponseDTO> UpdateClient(ClientDTO client);

    }
}
