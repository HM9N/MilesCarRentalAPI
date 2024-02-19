using MilesCarRentalApi.Context.MilesCarModels;


namespace MilesCarRentalApi.Services.Interfaces
{
    public interface IClientService
    {
        public Task<IEnumerable<Client>> GetCLients();
        public Task<Client?> GetById(int id);

        public Task<Client> CreateClient(Client newClient);


        public Task UpdateClient(int id, Client client);

        public Task DeleteClient(int id);

    }
}
