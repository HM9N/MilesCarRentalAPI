using MilesCarRentalApi.Context.MilesCarModels;
using MilesCarRentalApi.Utilities;


namespace MilesCarRentalApi.Services
{
    public interface IRentalService
    {

        public  Task<IEnumerable<Rental>> GetRentals();

        public Task<Rental?> GetById(int id);



        public Task<RentalCreationResult> CreateRental(Rental rental);

    }
}
