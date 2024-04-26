using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.OrderDTO
{
    public class OrderDelivery
    {
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

        [JsonProperty("deliveryDate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("deliveryDate")]
        public string deliveryDate { get; set; }
    }
}
