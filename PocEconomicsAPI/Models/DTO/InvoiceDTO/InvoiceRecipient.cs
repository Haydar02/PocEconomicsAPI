using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.InvoiceDTO
{
    public class InvoiceRecipient
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address")]
        public string address { get; set; }

        [JsonProperty("zip", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("zip")]
        public string zip { get; set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("city")]
        public string city { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("country")]
        public string country { get; set; }

        [JsonProperty("vatZone", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("vatZone")]
        public InvoiceVatZone vatZone { get; set; }
    }
}
