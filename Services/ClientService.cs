using Microsoft.EntityFrameworkCore;
using MilesCarRentalApi.Context;
using MilesCarRentalApi.Context.MilesCarModels;
using MilesCarRentalApi.Services.Interfaces;


namespace MilesCarRentalApi.Services
{
    public class ClientService : IClientService
    {
        private readonly MilesCarRentalDbContext _context;
        public ClientService(MilesCarRentalDbContext context)
        {
            _context=context;
        }

        public async Task<IEnumerable<Client>> GetCLients()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client?> GetById(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client> CreateClient(Client newClient)
        {
            _context.Clients.Add(newClient);
            await _context.SaveChangesAsync();

            return newClient;
        }

        public async Task UpdateClient(int id, Client client)
        {
            var existingClient = await GetById(id);

            if (existingClient != null)
            {
                existingClient.FirstName = client.FirstName;
                existingClient.LastName = client.LastName;
                existingClient.Phone = client.Phone;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteClient(int id)
        {
            var clientToDelete = await GetById(id);
            
            if (clientToDelete != null)
            {
                _context.Clients.Remove(clientToDelete);
                await _context.SaveChangesAsync();
            }

        }
    }
}
