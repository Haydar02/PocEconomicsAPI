using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.CustomerDTO
{
    public class CustomerTemplates
    {
        [JsonProperty("invoice")]
        [JsonPropertyName("invoice")]
        public string invoice { get; set; }

        [JsonProperty("invoiceLine")]
        [JsonPropertyName("invoiceLine")]
        public string invoiceLine { get; set; }

        [JsonProperty("self")]
        [JsonPropertyName("self")]
        public string self { get; set; }
    }
}
