using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.ResultDTO
{
    public class ResultUnitNetPrice
    {
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("errors")]
        public List<ResultError> errors { get; set; }
    }

}
