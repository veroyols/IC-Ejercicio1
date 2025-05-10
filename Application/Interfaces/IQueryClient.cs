using Domain.Entities;

namespace Application.Interfaces
{
    public interface IQueryClient
    {
        public Task<bool> ClientExists(string cuit);
        public Task<List<Client>> GetAllClients();
        public Task<Client?> GetClientByCuit(string cuit);

    }
}
