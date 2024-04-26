using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.OrderDTO
{
    public class OrderPaymentTerms
    {
        [JsonProperty("paymentTermsNumber", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("paymentTermsNumber")]
        public int paymentTermsNumber { get; set; }

        [JsonProperty("daysOfCredit", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("daysOfCredit")]
        public int daysOfCredit { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonProperty("paymentTermsType", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("paymentTermsType")]
        public string paymentTermsType { get; set; }
    }
}
