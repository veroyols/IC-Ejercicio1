using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command
{
    public class CommandClient : ICommandClient
    {
        private readonly AppDbContext _context;
        public CommandClient(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteClient(string cuit)
        {
            var client = await _context.Client.FindAsync(cuit);
            if (client == null)
                return false;

            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Client?> InsertClient(Client client)
        {
            var exists = await _context.Client.AnyAsync(cli => cli.CUIT == client.CUIT);
            if (exists)
                return null; 

            _context.Client.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client?> UpdateClient(Client client)
        {
            var existsClient = await _context.Client.FindAsync(client.CUIT);
            if (existsClient == null)
                return null;
            
            existsClient.Direccion = client.Direccion;
            existsClient.Activo = client.Activo;
            existsClient.Telefono = client.Telefono;
            await _context.SaveChangesAsync();

            return existsClient;
        }
    }
}
