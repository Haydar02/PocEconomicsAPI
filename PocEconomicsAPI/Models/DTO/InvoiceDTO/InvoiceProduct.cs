using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.InvoiceDTO
{
    public class InvoiceProduct
    {
        [JsonProperty("productNumber", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("productNumber")]
        public string productNumber { get; set; }

        [JsonProperty("self", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("self")]
        public string self { get; set; }
    }
}
