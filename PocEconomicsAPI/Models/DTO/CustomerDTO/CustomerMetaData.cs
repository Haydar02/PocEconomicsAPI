using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.CustomerDTO
{
    public class CustomerMetaData
    {
        [JsonProperty("delete")]
        [JsonPropertyName("delete")]
        public CustomerDelete delete { get; set; }

        [JsonProperty("replace")]
        [JsonPropertyName("replace")]
        public CustomerReplace replace { get; set; }
    }
}
