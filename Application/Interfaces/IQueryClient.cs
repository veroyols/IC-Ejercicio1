using Domain.Entities;

namespace Application.Interfaces
{
    public interface IQueryClient
    {
        public Task<List<Client?>> GetAllClients();
        public Task<Client?> GetClientByCuil(string cuil);

    }
}
