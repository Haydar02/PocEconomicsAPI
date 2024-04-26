using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.ResultDTO
{
    public class ResultError
    {

        [JsonProperty("customer", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("customer")]
        public ResultCustomer customer { get; set; }

        [JsonProperty("lines", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("lines")]
        public ResultLines lines { get; set; }

        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("quantity")]
        public ResultQuantity quantity { get; set; }

        [JsonProperty("layout", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("layout")]
        public ResultLayout layout { get; set; }
    }
}
