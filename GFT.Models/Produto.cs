using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace GFT.Models
{
    public class Produto
    {
        [JsonProperty("produtoId")]
        public Guid ProdutoId { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("ativo")]
        public bool Ativo { get; set; }
    }
}
