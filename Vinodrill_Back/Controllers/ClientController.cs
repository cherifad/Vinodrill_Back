﻿using Microsoft.AspNetCore.Mvc;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController: ControllerBase
    {
        //private readonly FilmRatingDBContexts dataRepository;
        private readonly IDataRepository<Client> dataRepository;

        public ClientController(IDataRepository<Client> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Clients
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Client>))]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Clients/GetClientById/5
        [HttpGet("GetClientById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Client))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Client>> GetClientById(int id)
        {
            var client = await dataRepository.GetById(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        //PUT: api/Client/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutClient(int id, Client client)
        {

            if (id != client.IdClient)
            {
                return BadRequest();
            }

            var userToUpdate = await dataRepository.GetById(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.Update(userToUpdate.Value, client);
                return NoContent();
            }
        }
    }
}
