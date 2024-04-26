using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.ResultDTO
{
    public class ResultErrorDetailes
    {
        [JsonProperty("propertyName")]
        [JsonPropertyName("propertyName")]
        public string propertyName { get; set; }

        [JsonProperty("errorMessage")]
        [JsonPropertyName("errorMessage")]
        public string errorMessage { get; set; }

        [JsonProperty("errorCode")]
        [JsonPropertyName("errorCode")]
        public string errorCode { get; set; }

        [JsonProperty("inputValue")]
        [JsonPropertyName("inputValue")]
        public string inputValue { get; set; }

        [JsonProperty("developerHint")]
        [JsonPropertyName("developerHint")]
        public string developerHint { get; set; }


        public int lineId { get; set; }
    }
}
