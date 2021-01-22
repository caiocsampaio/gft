using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GFT.Models;
using GFT.Repository.Context;

namespace GFT.Repository
{
    public class ProdutoRepository
    {
        private readonly GFTContext _context;

        public ProdutoRepository(GFTContext context)
        {
            _context = context;
        }

        public bool Delete(Produto produto)
        {
            _context.Produtos.Remove(produto);
            return _context.SaveChanges() > 0; // returns number of affected lines
        }

        public bool Delete(int id)
        {
            var produto = Get(id);
            if (produto == null)
            {
                return false;
            }
            _context.Remove(produto);
            return _context.SaveChanges() > 0; // returns number of affected lines
        }

        public Produto Get(int id)
        {
            return _context.Produtos.FirstOrDefault(c => c.ProdutoId == id);
        }

        public IEnumerable<Produto> GetAll()
        {
            return _context.Produtos.ToList();
        }

        public int Post(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return produto.ProdutoId;
        }

        public bool Put(int id, Produto produto)
        {
            var produtoToUpdate = Get(id);
            produtoToUpdate.Ativo = produto.Ativo;
            produtoToUpdate.Descricao = produto.Descricao;
            _context.Produtos.Update(produtoToUpdate);
            return _context.SaveChanges() > 0;
        }
    }
}
