using Newtonsoft.Json;
using PocEconimics.Models.DTO.OrderDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.OrderDTO
{
  

    public class OrderDTORoot
    {
        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("date")]
        public string date { get; set; }

        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("currency")]
        public string currency { get; set; }

        [JsonProperty("exchangeRate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("exchangeRate")]
        public int exchangeRate { get; set; }

        [JsonProperty("netAmount", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("netAmount")]
        public double netAmount { get; set; }

        [JsonProperty("netAmountInBaseCurrency", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("netAmountInBaseCurrency")]
        public double netAmountInBaseCurrency { get; set; }

        [JsonProperty("grossAmount", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("grossAmount")]
        public double grossAmount { get; set; }

        [JsonProperty("marginInBaseCurrency", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("marginInBaseCurrency")]
        public double marginInBaseCurrency { get; set; }

        [JsonProperty("marginPercentage", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("marginPercentage")]
        public double marginPercentage { get; set; }

        [JsonProperty("vatAmount", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("vatAmount")]
        public double vatAmount { get; set; }

        [JsonProperty("roundingAmount", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("roundingAmount")]
        public double roundingAmount { get; set; }

        [JsonProperty("costPriceInBaseCurrency", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("costPriceInBaseCurrency")]
        public double costPriceInBaseCurrency { get; set; }

        [JsonProperty("paymentTerms", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("paymentTerms")]
        public OrderPaymentTerms paymentTerms { get; set; }

        [JsonProperty("customer", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("customer")]
        public OrderCustomer customer { get; set; }

        [JsonProperty("recipient", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("recipient")]
        public OrderRecipient recipient { get; set; }

        [JsonProperty("delivery", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("delivery")]
        public OrderDelivery delivery { get; set; }

        [JsonProperty("references", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("references")]
        public OrderReferences references { get; set; }

        [JsonProperty("layout", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("layout")]
        public OrderLayout layout { get; set; }

        [JsonProperty("lines", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("lines")]
        public List<OrderLine> lines { get; set; }
    }

 

  


}