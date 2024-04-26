using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.OrderDTO
{
    public class OrderReferences
    {
        [JsonProperty("other", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("other")]
        public string other { get; set; }
    }
}
