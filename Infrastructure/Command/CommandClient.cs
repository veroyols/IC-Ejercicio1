using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Command
{
    public class CommandClient : ICommandClient
    {
        private readonly AppDbContext _context;
        public CommandClient(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteClient(string cuil)
        {
            throw new NotImplementedException();
        }

        public async Task<Client?> InsertClient(Client clientDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<Client?> UpdateClient(Client clientDTO)
        {
            throw new NotImplementedException();
        }
    }
}
