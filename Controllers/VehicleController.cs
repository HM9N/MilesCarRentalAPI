using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilesCarRentalApi.Context.MilesCarModels;
using MilesCarRentalApi.Services;
using MilesCarRentalApi.Utilities;

namespace MilesCarRentalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _service;

        public VehicleController(IVehicleService service)
        {
            _service=service;
        }

        [HttpGet("getVehicles")]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        {
            var vehicles = await _service.GetVehicles();
            if (vehicles == null || !vehicles.Any())
            {
                return NoContent();
            }
            return Ok(vehicles);
        }


        [HttpGet("getAvailableVehicles/{idlocation}")]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetAvailableVehiclesByLocation(int idlocation)
        {
            var vehicles = await _service.GetAvailableVehiclesByLocation(idlocation);
            if (vehicles == null || !vehicles.Any())
            {
                return NoContent();
            }
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetById(int id)
        {
            var vehicle = await _service.GetById(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        [HttpPost]
        public async Task<ActionResult<Vehicle>> CreateVehicle(Vehicle vehicle)
        {
            if (vehicle == null) return BadRequest(new { message = $"Falta la información del vehiculo" });

            var newVehicle = await _service.CreateVehicle(vehicle);

            return CreatedAtAction(nameof(GetById), new { id = newVehicle.IdVehicle }, newVehicle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.IdVehicle)
            {
                return BadRequest(new { message = $"Los id no concuerdan" });
            }

            var vehicleToUpdate = await _service.GetById(id);
            if (vehicleToUpdate != null)
            {
                await _service.UpdateVehicleAvailability(id, vehicle);
                return Ok(new { message = $"Vehicle Modified" });
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var vehicleToDelete = await _service.GetById(id);
            if (vehicleToDelete != null)
            {
                await _service.DeleteVehicle(id);
                return Ok(new { message = $"Vehicle Deleted" });
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("returnVehicle")]
        public async Task<IActionResult> ReturnVehicle([FromBody] ReturnVehicleRequest request)
        {
            int idclient = request.IdClient;
            int idVehicle = request.IdVehicle;

            var vehicle = await _service.GetById(idVehicle);

            if (vehicle == null)
            {
                return NotFound();
            }

            if (vehicle.Availability == "Available")
            {
                return BadRequest(new { message = "This vehicle has not been rented." });
            }

            var checkChangeLocation = await _service.UpdateVehicleLocation(idclient, idVehicle);

            if (!checkChangeLocation)
            {
                return BadRequest(new { message = "Rental not found" });
            }

            await _service.UpdateVehicleAvailability(idVehicle, "Available");
            return Ok(new { message = $"Vehicle returned and status changed to available." });

        }

    }
}
