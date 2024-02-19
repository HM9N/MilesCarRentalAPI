using Microsoft.EntityFrameworkCore;
using MilesCarRentalApi.Context;
using MilesCarRentalApi.Context.MilesCarModels;

namespace MilesCarRentalApi.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly MilesCarRentalDbContext _context;
        public VehicleService(MilesCarRentalDbContext context)
        {
            _context=context;
        }

        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle?> GetById(int id)
        {
            return await _context.Vehicles.FindAsync(id);
        }

        public async Task<Vehicle> CreateVehicle(Vehicle newVehicle)
        {
            _context.Vehicles.Add(newVehicle);
            await _context.SaveChangesAsync();

            return newVehicle;
        }

        public async Task UpdateVehicleAvailability(int id, Vehicle vehicle)
        {
            var existingVehicle = await GetById(id);

            if (existingVehicle != null)
            {

                existingVehicle.Brand = vehicle.Brand;
                existingVehicle.Model = vehicle.Model;
                existingVehicle.Type = vehicle.Type;
                existingVehicle.Availability = vehicle.Availability;
                existingVehicle.IdLocation = vehicle.IdLocation;

                    await _context.SaveChangesAsync();
            }
        }

            public async Task DeleteVehicle(int id)
            {
                var vehicleToDelete = await GetById(id);

                if (vehicleToDelete != null)
                {
                    _context.Vehicles.Remove(vehicleToDelete);
                    await _context.SaveChangesAsync();
                }

            }

            public async Task<IEnumerable<Vehicle>> GetAvailableVehiclesByLocation(int idLocation)
            {
                var availableVehicles = await _context.Vehicles
                    .Where(v => v.IdLocation == idLocation && v.Availability == "Available")
                    .ToListAsync();

                return availableVehicles;
            }

            public async Task UpdateVehicleAvailability(int vehicleId, string availability)
            {
                var vehicle = await _context.Vehicles.FindAsync(vehicleId);
                if (vehicle != null)
                {
                    vehicle.Availability = availability;
                    await _context.SaveChangesAsync();
                }
            }

            public async Task<bool> UpdateVehicleLocation(int clientId, int vehicleId)
            {
                var rental = await _context.Rentals
                    .Where(r => r.IdClient == clientId && r.IdVehicle == vehicleId)
                    .FirstOrDefaultAsync();

                if (rental == null)
                    return false;

                var vehicleToUpdate = await GetById(vehicleId);

                vehicleToUpdate.IdLocation = rental.IdReturnLocation;

                await _context.SaveChangesAsync();
                return true; // Se actualizó exitosamente
            }


        }
    }

