using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICommandClient
    {
        public Task<bool> DeleteClient(string cuit);
        public Task<Client?> InsertClient(Client client);
        public Task<Client?> UpdateClient(Client client);

    }
}
