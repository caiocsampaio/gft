using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace GFT.Models
{
    public class Cliente
    {
        [JsonProperty("clienteId")]
        public int ClienteId { get; set; }

        [JsonProperty("nome")]
        [Required]
        public string Nome { get; set; }

        [JsonProperty("ativo")]
        public bool Ativo { get; set; }
    }
}
