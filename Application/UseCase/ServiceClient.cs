using Application.DTO;
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCase
{
    public class ServiceClient : IServiceClient
    {
        private readonly ICommandClient _commandClient;
        private readonly IQueryClient _queryClient;
        public ServiceClient(ICommandClient commandClient, IQueryClient queryClient)
        {
            _commandClient = commandClient;
            _queryClient = queryClient;
        }

        public async Task<ResponseDTO<ClientDTO?>> CreateClient(ClientDTO clientDto)
        {
            bool clientIsInDb = await _queryClient.ClientExists(clientDto.CUIT);

            if (clientIsInDb)
            {
                var existingClient = await _queryClient.GetClientByCuit(clientDto.CUIT);
                return new ResponseDTO<ClientDTO?>
                {
                    Success = false,
                    Message = "Ya existe un cliente con ese CUIT.",
                    Data = new ClientDTO(existingClient)
                };
            }
            try
            {
                var clientResponse = await _commandClient.InsertClient(new Client
                {
                    CUIT = clientDto.CUIT,
                    RazonSocial = clientDto.RazonSocial,
                    Telefono = clientDto.Telefono,
                    Direccion = clientDto.Direccion,
                    Activo = clientDto.Activo
                });
                    return new ResponseDTO<ClientDTO?>()
                    {
                        Success = true,
                        Message = "El nuevo cliente se ha insertado correctamente.",
                        Data = new ClientDTO(clientResponse)
                    };
            } catch
            {
                return new ResponseDTO<ClientDTO?>()
                {
                    Success = false,
                    Message = "No se ha podido insertar el nuevo cliente.",
                };
            }
        }

        public async Task<ResponseDTO<ClientDTO?>> DeleteClient(string cuit)
        {
            bool clientIsInDb = await _queryClient.ClientExists(cuit);

            if (!clientIsInDb)
            {
                return new ResponseDTO<ClientDTO?>
                {
                    Success = false,
                    Message = "No existe un cliente con ese CUIT.",
                };
            }
            
            bool wasDeleted = await _commandClient.DeleteClient(cuit);
            if (wasDeleted)
            {
                return new ResponseDTO<ClientDTO?>()
                {
                    Success = true,
                    Message = "El cliente se ha eliminado correctamente.",
                };
            }
            return new ResponseDTO<ClientDTO?>()
            {
                Success = false,
                Message = "El cliente no se ha eliminado.",
            };
        }

        public async Task<List<ClientDTO>> GetAllClientDtos()
        {
            var clients = await _queryClient.GetAllClients();
            var clientDtos = new List<ClientDTO>();

            foreach (var client in clients)
            {
                clientDtos.Add(new ClientDTO(client));
            }

            return clientDtos;
        }

        public async Task<ResponseDTO<ClientDTO?>> GetClientByCUIT(string cuit)
        {
            bool clientIsInDb = await _queryClient.ClientExists(cuit);

            if (!clientIsInDb)
            {
                return new ResponseDTO<ClientDTO?>
                {
                    Success = false,
                    Message = "No existe un cliente con ese CUIT.",
                };
            }

            var existingClient = await _queryClient.GetClientByCuit(cuit);
            
            return new ResponseDTO<ClientDTO?>
            {
                Success = true,
                Message = "Cliente encontrado.",
                Data = new ClientDTO(existingClient)
            };
        }

        public async Task<ResponseDTO<ClientDTO?>> UpdateClient(ClientDTO clientDTO)
        {
            bool clientIsInDb = await _queryClient.ClientExists(clientDTO.CUIT);

            if (!clientIsInDb)
            {
                return new ResponseDTO<ClientDTO?>
                {
                    Success = false,
                    Message = "No existe un cliente con ese CUIT.",
                };
            }
            try
            {
                var updatedClient = await _commandClient.UpdateClient(new Client
                {
                    CUIT = clientDTO.CUIT,
                    RazonSocial = clientDTO.RazonSocial,
                    Telefono = clientDTO.Telefono,
                    Direccion = clientDTO.Direccion,
                    Activo = clientDTO.Activo
                });
                return new ResponseDTO<ClientDTO?>
                {
                    Success = true,
                    Message = "El cliente se ha actualizado correctamente.",
                    Data = new ClientDTO(updatedClient)
                };
            } catch
            {
                return new ResponseDTO<ClientDTO?>
                {
                    Success = true,
                    Message = "El cliente no se ha actualizado.",
                };
            }
        }
    }
}
