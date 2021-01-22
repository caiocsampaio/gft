using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GFT.Models;
using GFT.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GFT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repository;

        public ClienteController(IClienteRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var clientes = _repository.GetAll();
            return Ok(clientes);
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cliente = _repository.Get(id);
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clienteId = _repository.Post(cliente);
            return Ok(clienteId);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Put(id, cliente);
            return Ok();
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }
    }
}
