using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class QueryClient : IQueryClient
    {
        private readonly AppDbContext _context;
        public QueryClient(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> ClientExists(string cuit)
        {
            return await _context.Client.AnyAsync(c => c.CUIT == cuit);
        }

        public async Task<List<Client>> GetAllClients()
        {
            return await _context.Client.ToListAsync();
        }

        public async Task<Client?> GetClientByCuit(string cuit)
        {
            return await _context.Client.FirstOrDefaultAsync(client => client.CUIT == cuit);
        }
    }
}
