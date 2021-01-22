using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace GFT.Models
{
    public class Pedido
    {
        [JsonProperty("pedidoId")]
        public int PedidoId { get; set; }

        [JsonProperty("clienteId")]
        public int ClienteId { get; set; }

        [JsonProperty("produtoId")]
        public int ProdutoId { get; set; }

        [JsonProperty("ativo")]
        public bool Ativo { get; set; }
    }
}
