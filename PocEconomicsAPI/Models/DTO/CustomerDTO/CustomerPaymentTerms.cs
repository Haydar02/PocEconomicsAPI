using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.CustomerDTO
{
    public class CustomerPaymentTerms
    {
        [JsonProperty("paymentTermsNumber")]
        [JsonPropertyName("paymentTermsNumber")]
        public int paymentTermsNumber { get; set; }

        [JsonProperty("self")]
        [JsonPropertyName("self")]
        public string self { get; set; }
    }
}
