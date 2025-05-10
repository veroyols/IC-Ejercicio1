using Application.DTO;
using Application.Interfaces;

namespace Application.UseCase
{
    public class ServiceClient : IServiceClient
    {
        public Task<ResponseDTO> CreateClient(ClientDTO client)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> DeleteClient(string cuit)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClientDTO>> GetAllClientDtos()
        {
            throw new NotImplementedException();
        }

        public Task<ClientDTO> GetClientByCUIT(string cuit)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> UpdateClient(ClientDTO client)
        {
            throw new NotImplementedException();
        }
    }
}
