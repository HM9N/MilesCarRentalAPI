using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilesCarRentalApi.Context.MilesCarModels;
using MilesCarRentalApi.Services;

namespace MilesCarRentalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _service;
        public RentalController(IRentalService service)
        {
            _service = service;
        }

        [HttpGet("getRentals")]
        [ProducesResponseType(200)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<Rental>>> GetRentals()
        {
            var Rentals = await _service.GetRentals();
            if (Rentals == null || !Rentals.Any())
            {
                return NoContent();
            }
            return Ok(Rentals);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRental(Rental rental)
        {
            var result = await _service.CreateRental(rental);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rental>> GetById(int id)
        {
            var rental = await _service.GetById(id);

            if (rental == null)
            {
                return NotFound();
            }

            return Ok(rental);
        }


    }
}
