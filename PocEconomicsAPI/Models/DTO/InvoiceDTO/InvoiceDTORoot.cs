using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.InvoiceDTO
{
    public class InvoiceDTORoot
    {
        [JsonProperty("bookedInvoiceNumber", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("bookedInvoiceNumber")]
        public int bookedInvoiceNumber { get; set; }

        [JsonProperty("orderNumber", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("orderNumber")]
        public int orderNumber { get; set; }

        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("date")]
        public string date { get; set; }

        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("currency")]
        public string currency { get; set; }

        [JsonProperty("exchangeRate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("exchangeRate")]
        public double exchangeRate { get; set; }

        [JsonProperty("netAmount", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("netAmount")]
        public double netAmount { get; set; }

        [JsonProperty("netAmountInBaseCurrency", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("netAmountInBaseCurrency")]
        public double netAmountInBaseCurrency { get; set; }

        [JsonProperty("grossAmount", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("grossAmount")]
        public double grossAmount { get; set; }

        [JsonProperty("grossAmountInBaseCurrency", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("grossAmountInBaseCurrency")]
        public double grossAmountInBaseCurrency { get; set; }

        [JsonProperty("vatAmount", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("vatAmount")]
        public double vatAmount { get; set; }

        [JsonProperty("roundingAmount", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("roundingAmount")]
        public double roundingAmount { get; set; }

        [JsonProperty("remainder", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("remainder")]
        public double remainder { get; set; }

        [JsonProperty("remainderInBaseCurrency", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("remainderInBaseCurrency")]
        public double remainderInBaseCurrency { get; set; }

        [JsonProperty("dueDate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("dueDate")]
        public string dueDate { get; set; }

        [JsonProperty("paymentTerms", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("paymentTerms")]
        public InvoicePaymentTerms paymentTerms { get; set; }

        [JsonProperty("customer", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("customer")]
        public InvoiceCustomer customer { get; set; }

        [JsonProperty("recipient", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("recipient")]
        public InvoiceRecipient recipient { get; set; }

        [JsonProperty("layout", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("layout")]
        public InvoiceLayout layout { get; set; }

        [JsonProperty("pdf", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("pdf")]
        public InvoicePdf pdf { get; set; }

        [JsonProperty("lines", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("lines")]
        public List<InvoiceLine> lines { get; set; }

        [JsonProperty("sent", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("sent")]
        public string sent { get; set; }

        [JsonProperty("self", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("self")]
        public string self { get; set; }
    }

}
