using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.ResultDTO
{
    public class SchemavalidationDTOResult
    {
        [JsonProperty("message")]
        [JsonPropertyName("message")]
        public string message { get; set; }

        [JsonProperty("errorCode")]
        [JsonPropertyName("errorCode")]
        public string errorCode { get; set; }

        [JsonProperty("developerHint")]
        [JsonPropertyName("developerHint")]
        public string developerHint { get; set; }

        [JsonProperty("logId")]
        [JsonPropertyName("logId")]
        public string logId { get; set; }

        [JsonProperty("httpStatusCode")]
        [JsonPropertyName("httpStatusCode")]
        public int httpStatusCode { get; set; }

        [JsonProperty("errors")]
        [JsonPropertyName("errors")]
        public List<string> errors { get; set; }

        [JsonProperty("logTime")]
        [JsonPropertyName("logTime")]
        public DateTime logTime { get; set; }

        [JsonProperty("schemaPath")]
        [JsonPropertyName("schemaPath")]
        public string schemaPath { get; set; }
    }
}
