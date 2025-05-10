using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Query
{
    public class QueryClient : IQueryClient
    {
        private readonly AppDbContext _context;
        public QueryClient(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Client?>> GetAllClients()
        {
            throw new NotImplementedException();
        }

        public async Task<Client?> GetClientByCuil(string cuil)
        {
            throw new NotImplementedException();
        }
    }
}
