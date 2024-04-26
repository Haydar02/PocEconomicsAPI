using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.OrderDTO
{
    public class OrderLine
    {
        [JsonProperty("unit", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("unit")]
        public OrderUnit unit { get; set; }

        [JsonProperty("product", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("product")]
        public OrderProduct product { get; set; }

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

        [JsonProperty("totalNetAmount", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("totalNetAmount")]
        public double totalNetAmount { get; set; }

        [JsonProperty("marginInBaseCurrency", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("marginInBaseCurrency")]
        public double marginInBaseCurrency { get; set; }

        [JsonProperty("marginPercentage", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("marginPercentage")]
        public double marginPercentage { get; set; }
    }
}
