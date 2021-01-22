using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GFT.Models;
using GFT.Repository.Context;
using GFT.Repository.Interfaces;

namespace GFT.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly GFTContext _context;

        public ClienteRepository(GFTContext context)
        {
            _context = context;
        }

        public bool Delete(Cliente data)
        {
            _context.Clientes.Remove(data);
            return _context.SaveChanges() > 0; // returns number of affected lines
        }

        public bool Delete(int id)
        {
            var cliente = Get(id);
            if (cliente == null)
            {
                return false;
            }
            _context.Remove(cliente);
            return _context.SaveChanges() > 0; // returns number of affected lines
        }

        public Cliente Get(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.ClienteId == id);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _context.Clientes.ToList();
        }

        public int Post(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return cliente.ClienteId;
        }

        public bool Put(int id, Cliente cliente)
        {
            var clienteToUpdate = Get(id);
            clienteToUpdate.Ativo = cliente.Ativo;
            clienteToUpdate.Nome = cliente.Nome;
            _context.Clientes.Update(clienteToUpdate);
            return _context.SaveChanges() > 0;
        }
    }
}
