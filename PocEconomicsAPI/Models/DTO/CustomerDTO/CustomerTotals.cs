using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.CustomerDTO
{
    public class CustomerTotals
    {
        [JsonProperty("drafts")]
        [JsonPropertyName("drafts")]
        public string drafts { get; set; }

        [JsonProperty("booked")]
        [JsonPropertyName("booked")]
        public string booked { get; set; }

        [JsonProperty("self")]
        [JsonPropertyName("self")]
        public string self { get; set; }
    }
}
