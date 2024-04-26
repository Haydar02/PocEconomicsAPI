using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.OrderDTO
{
    public class OrderVatZone
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonProperty("vatZoneNumber", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("vatZoneNumber")]
        public int vatZoneNumber { get; set; }

        [JsonProperty("enabledForCustomer", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("enabledForCustomer")]
        public bool enabledForCustomer { get; set; }

        [JsonProperty("enabledForSupplier", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("enabledForSupplier")]
        public bool enabledForSupplier { get; set; }
    }
}
