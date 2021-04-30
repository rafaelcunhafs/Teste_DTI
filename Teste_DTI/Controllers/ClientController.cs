using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Teste_DTI.Models;
using Teste_DTI.Services;

namespace Teste_DTI.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return Ok(_clientService.Get());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {
            var client = _clientService.GetById(id);

            if (client != null)
                return Ok(_clientService.GetById(id));

            return NotFound($"Cliente com Id: {id} não encontrado.");
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create(Client client)
        {
            _clientService.Create(client);

            var uri = $"{HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path}/{client.Id}";

            return Created(uri, client);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            var client = _clientService.GetById(id);

            if (client == null)
                return NotFound($"Cliente com Id: {id} não encontrado.");

            _clientService.Delete(client);
            return Ok(client);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Edit(Guid id, Client client)
        {
            var existingClient = _clientService.GetById(id);

            if (existingClient == null)
                return NotFound($"Cliente com Id: {id} não encontrado.");

            client.Id = existingClient.Id;
            _clientService.Edit(client);

            return Ok(client);
        }
    }
}
