using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GFT.Models;
using GFT.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GFT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _repository;

        public PedidoController(IPedidoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pedidos = _repository.GetAll();
            return Ok(pedidos);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pedido = _repository.Get(id);
            return Ok(pedido);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pedidoId = _repository.Post(pedido);
            return Ok(pedidoId);
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Put(id, pedido);
            return Ok();
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }
    }
}
