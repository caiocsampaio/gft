using GFT.Models;
using Microsoft.EntityFrameworkCore;

namespace GFT.Repository.Context
{
    public class GFTContext : DbContext
    {
        public GFTContext(DbContextOptions<GFTContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
