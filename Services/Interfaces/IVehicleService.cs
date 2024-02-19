using Microsoft.EntityFrameworkCore;
using MilesCarRentalApi.Context;
using MilesCarRentalApi.Context.MilesCarModels;

namespace MilesCarRentalApi.Services
{
    public interface IVehicleService
    {
        public Task<IEnumerable<Vehicle>> GetVehicles();

        public Task<Vehicle?> GetById(int id);

        public Task<Vehicle> CreateVehicle(Vehicle newVehicle);

        public Task UpdateVehicleAvailability(int id, Vehicle vehicle);


        public  Task DeleteVehicle(int id);


        public  Task<IEnumerable<Vehicle>> GetAvailableVehiclesByLocation(int idLocation);


        public  Task UpdateVehicleAvailability(int vehicleId, string availability);


        public  Task<bool> UpdateVehicleLocation(int clientId, int vehicleId);


    }
}

