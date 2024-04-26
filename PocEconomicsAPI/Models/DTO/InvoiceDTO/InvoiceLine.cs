using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.InvoiceDTO
{
    public class InvoiceLine
    {
        [JsonProperty("lineNumber", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("lineNumber")]
        public int lineNumber { get; set; }

        [JsonProperty("sortKey", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("sortKey")]
        public int sortKey { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("quantity")]
        public double quantity { get; set; }

        [JsonProperty("unitNetPrice", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("unitNetPrice")]
        public double unitNetPrice { get; set; }

        [JsonProperty("discountPercentage", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("discountPercentage")]
        public double discountPercentage { get; set; }

        [JsonProperty("unitCostPrice", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("unitCostPrice")]
        public double unitCostPrice { get; set; }

        [JsonProperty("vatRate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("vatRate")]
        public double vatRate { get; set; }

        [JsonProperty("vatAmount", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("vatAmount")]
        public double vatAmount { get; set; }

        [JsonProperty("totalNetAmount", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("totalNetAmount")]
        public double totalNetAmount { get; set; }

        [JsonProperty("product", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("product")]
        public InvoiceProduct product { get; set; }
    }
}
