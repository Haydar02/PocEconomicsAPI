using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.OrderDTO
{
    public class OrderLayout
    {
        [JsonProperty("layoutNumber", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("layoutNumber")]
        public int layoutNumber { get; set; }
    }
}
