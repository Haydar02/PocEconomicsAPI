using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.ResultDTO
{
    public class ResultItem
    {
        [JsonProperty("arrayIndex")]
        [JsonPropertyName("arrayIndex")]
        public int arrayIndex { get; set; }

        [JsonProperty("product")]
        [JsonPropertyName("product")]
        public ResultProduct product { get; set; }

        [JsonProperty("unitNetPrice")]
        [JsonPropertyName("unitNetPrice")]
        public ResultUnitNetPrice unitNetPrice { get; set; }
    }
}
