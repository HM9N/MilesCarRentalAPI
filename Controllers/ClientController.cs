using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilesCarRentalApi.Context.MilesCarModels;
using MilesCarRentalApi.Services.Interfaces;

namespace MilesCarRentalApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;
        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpGet("getClients")]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            var clients = await _service.GetCLients();
            if (clients == null || !clients.Any())
            {
                return NoContent();
            }
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetById(int id)
        {
            var client = await _service.GetById(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<Client>> CreateClient(Client client)
        {
            if (client == null) return BadRequest(new {message=$"Falta información"});

            var newClient = await _service.CreateClient(client);

            return CreatedAtAction(nameof(GetById), new { id = newClient.IdClient }, newClient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, Client client)
        {
            if (id != client.IdClient)
            {
                return BadRequest(new { message = $"Los ID no concuerdan" });
            }

            var clientToUpdate = await _service.GetById(id);
            if(clientToUpdate != null)
            {
                await _service.UpdateClient(id, client);
                return Ok(new { message = $"Cliente modificado" });
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var clientToDelete = await _service.GetById(id);
            if (clientToDelete != null)
            {
                await _service.DeleteClient(id);
                return Ok(new { message = $"Cliente eliminado" });
            }
            else
            {
                return NotFound();
            }
        }
    }
}
