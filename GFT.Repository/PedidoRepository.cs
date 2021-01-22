using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GFT.Models;
using GFT.Repository.Context;

namespace GFT.Repository
{
    public class PedidoRepository
    {
        private readonly GFTContext _context;

        public PedidoRepository(GFTContext context)
        {
            _context = context;
        }

        public bool Delete(Pedido pedido)
        {
            _context.Pedidos.Remove(pedido);
            return _context.SaveChanges() > 0; // returns number of affected lines
        }

        public bool Delete(int id)
        {
            var pedido = Get(id);
            if (pedido == null)
            {
                return false;
            }
            _context.Remove(pedido);
            return _context.SaveChanges() > 0; // returns number of affected lines
        }

        public Pedido Get(int id)
        {
            return _context.Pedidos.FirstOrDefault(c => c.PedidoId == id);
        }

        public IEnumerable<Pedido> GetAll()
        {
            return _context.Pedidos.ToList();
        }

        public int Post(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
            return pedido.ProdutoId;
        }

        public bool Put(int id, Pedido pedido)
        {
            var pedidoToUpdate = Get(id);
            pedidoToUpdate.Ativo = pedido.Ativo;
            pedidoToUpdate.ProdutoId = pedido.ProdutoId;
            pedidoToUpdate.ClienteId = pedido.ClienteId;
            _context.Pedidos.Update(pedidoToUpdate);
            return _context.SaveChanges() > 0;
        }
    }
}

