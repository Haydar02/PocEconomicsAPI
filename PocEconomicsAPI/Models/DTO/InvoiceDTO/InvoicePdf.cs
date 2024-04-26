using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.InvoiceDTO
{
    public class InvoicePdf
    {
        [JsonProperty("download", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("download")]
        public string download { get; set; }
    }
}
