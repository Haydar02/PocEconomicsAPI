using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.CustomerDTO
{

    public class CustomerDTORoot
    {
        //[JsonProperty("License")]
        //[JsonPropertyName("License")]
        //public int License { get; set; }

        [JsonProperty("customerNumber")]
        [JsonPropertyName("customerNumber")]
        public int customerNumber { get; set; }

        [JsonProperty("currency")]
        [JsonPropertyName("currency")]
        public string currency { get; set; }

        [JsonProperty("paymentTerms")]
        [JsonPropertyName("paymentTerms")]
        public CustomerPaymentTerms paymentTerms { get; set; }

        [JsonProperty("customerGroup")]
        [JsonPropertyName("customerGroup")]
        public CustomerGroup customerGroup { get; set; }

        [JsonProperty("address")]
        [JsonPropertyName("address")]
        public string address { get; set; }

        [JsonProperty("balance")]
        [JsonPropertyName("balance")]
        public double balance { get; set; }

        [JsonProperty("dueAmount")]
        [JsonPropertyName("dueAmount")]
        public double dueAmount { get; set; }

        [JsonProperty("city")]
        [JsonPropertyName("city")]
        public string city { get; set; }

        [JsonProperty("email")]
        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonProperty("zip")]
        [JsonPropertyName("zip")]
        public string zip { get; set; }

        [JsonProperty("vatZone")]
        [JsonPropertyName("vatZone")]
        public CustomerVatZone vatZone { get; set; }

        [JsonProperty("lastUpdated")]
        [JsonPropertyName("lastUpdated")]
        public DateTime lastUpdated { get; set; }

        [JsonProperty("contacts")]
        [JsonPropertyName("contacts")]
        public string contacts { get; set; }

        [JsonProperty("templates")]
        [JsonPropertyName("templates")]
        public CustomerTemplates templates { get; set; }

        [JsonProperty("totals")]
        [JsonPropertyName("totals")]
        public CustomerTotals totals { get; set; }

        [JsonProperty("deliveryLocations")]
        [JsonPropertyName("deliveryLocations")]
        public string deliveryLocations { get; set; }

        [JsonProperty("invoices")]
        [JsonPropertyName("invoices")]
        public CustomerInvoices invoices { get; set; }

        [JsonProperty("eInvoicingDisabledByDefault")]
        [JsonPropertyName("eInvoicingDisabledByDefault")]
        public bool eInvoicingDisabledByDefault { get; set; }

        [JsonProperty("metaData")]
        [JsonPropertyName("metaData")]
        public CustomerMetaData metaData { get; set; }

        [JsonProperty("self")]
        [JsonPropertyName("self")]
        public string self { get; set; }
       
    }

   








}
