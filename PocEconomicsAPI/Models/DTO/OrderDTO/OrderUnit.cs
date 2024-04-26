using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.OrderDTO
{
    public class OrderUnit
    {
        [JsonProperty("unitNumber", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("unitNumber")]
        public int unitNumber { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string name { get; set; }
    }
}
