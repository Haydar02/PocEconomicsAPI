using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.InvoiceDTO
{
    public class InvoiceLayout
    {
        [JsonProperty("layoutNumber", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("layoutNumber")]
        public int layoutNumber { get; set; }

        [JsonProperty("self", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("self")]
        public string self { get; set; }
    }

}
