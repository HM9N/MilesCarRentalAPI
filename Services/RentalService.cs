using Microsoft.EntityFrameworkCore;
using MilesCarRentalApi.Context;
using MilesCarRentalApi.Context.MilesCarModels;
using MilesCarRentalApi.Utilities;
using System.Globalization;

namespace MilesCarRentalApi.Services
{
    public class RentalService : IRentalService
    {
        private readonly MilesCarRentalDbContext _context;
        private readonly IVehicleService _vehicleService;
        public RentalService(MilesCarRentalDbContext context, IVehicleService vehicleService)
        {
            _context=context;
            _vehicleService=vehicleService;
        }

        public async Task<IEnumerable<Rental>> GetRentals()
        {
            return await _context.Rentals.ToListAsync();
        }

        public async Task<Rental?> GetById(int id)
        {
            return await _context.Rentals.FindAsync(id);
        }


        public async Task<RentalCreationResult> CreateRental(Rental rental)
        {
            // validations
            var validationError = await ValidateRental(rental);
            if (validationError != null)
            {
                return validationError;
            }

            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();

            // change vehicle availability 
            await _vehicleService.UpdateVehicleAvailability(rental.IdVehicle, "Rented");

            return new RentalCreationResult(true, "Rental Created.");
        }

        private async Task<RentalCreationResult?> ValidateRental(Rental rental)
        {
            // Check if the vehicle is already being rented.
            if (!await IsVehicleAvailable(rental.IdVehicle))
            {
                return new RentalCreationResult(false, "The specified vehicle is already rented or not exists.");
            }
            // Check if the client exists
            if (!await ClientExists(rental.IdClient))
            {
                return new RentalCreationResult(false, "The specified client does not exist.");
            }


            // Check if the pickup location exists
            if (!await LocationExists(rental.IdPickupLocation))
            {
                return new RentalCreationResult(false, "The specified pickup location does not exist.");
            }

            // Check if the return location exists
            if (!await LocationExists(rental.IdReturnLocation))
            {
                return new RentalCreationResult(false, "The specified return location does not exist.");
            }

            // Check if the start date and end date are in the correct format
            if (!IsValidDateFormat(rental.StartDate) || !IsValidDateFormat(rental.EndDate))
            {
                return new RentalCreationResult(false, "Invalid date format. The date format should be 'yyyy-MM-dd'.");
            }

            if (rental.StartDate >= rental.EndDate)
            {
                return new RentalCreationResult(false, "Start date must be before end date.");
            }

            // Check if the start date is not earlier than today
            if (rental.StartDate.Date < DateTime.Today)
            {
                return new RentalCreationResult(false, "Start date cannot be earlier than today.");
            }

            return null;
        }

        private async Task<bool> ClientExists(int clientId)
        {
            return await _context.Clients.AnyAsync(c => c.IdClient == clientId);
        }

        private async Task<bool> LocationExists(int locationId)
        {
            return await _context.Locations.AnyAsync(l => l.IdLocation == locationId);
        }
        private bool IsValidDateFormat(DateTime date)
        {
            string dateString = date.ToString("yyyy-MM-dd");

            return DateTime.TryParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }

        private async Task<bool> IsVehicleAvailable(int vehicleId)
        {
            var vehicle = await _context.Vehicles.FindAsync(vehicleId);
            return vehicle != null && vehicle.Availability != "Rented";
        }

    }
}
