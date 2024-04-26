using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.CustomerDTO
{
    public class CustomerGroup
    {
        [JsonProperty("customerGroupNumber")]
        [JsonPropertyName("customerGroupNumber")]
        public int customerGroupNumber { get; set; }

        [JsonProperty("self")]
        [JsonPropertyName("self")]
        public string self { get; set; }
    }
}
