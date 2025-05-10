using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICommandClient
    {
        public Task<bool> DeleteClient(string cuil);
        public Task<Client?> InsertClient(Client clientDTO);
        public Task<Client?> UpdateClient(Client clientDTO);

    }
}
