using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace GFT.Models
{
    public class Cliente
    {
        [JsonProperty("clienteId")]
        public Guid ClienteId { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("ativo")]
        public bool Ativo { get; set; }
    }
}
