using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.CustomerDTO
{
    public class CustomerReplace
    {
        [JsonProperty("description")]
        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonProperty("href")]
        [JsonPropertyName("href")]
        public string href { get; set; }

        [JsonProperty("httpMethod")]
        [JsonPropertyName("httpMethod")]
        public string httpMethod { get; set; }
    }
}
