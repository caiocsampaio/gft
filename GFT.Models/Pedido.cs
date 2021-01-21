using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace GFT.Models
{
    public class Pedido
    {
        [JsonProperty("pedidoId")]
        public Guid PedidoId { get; set; }

        [JsonProperty("clienteId")]
        public Guid ClienteId { get; set; }

        [JsonProperty("produtoId")]
        public Guid ProdutoId { get; set; }

        [JsonProperty("ativo")]
        public bool Ativo { get; set; }
    }
}
