using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.InvoiceDTO
{
    public class InvoiceCollectionDTO
    {

        [JsonProperty("invoices")]
        [JsonPropertyName("invoices")]
        public List<InvoiceDTORoot> invoices { get; set; }

        [JsonProperty("customerId")]
        [JsonPropertyName("customerId")]
        public int customerId { get; set; }

        [JsonProperty("invoiceDate")]
        [JsonPropertyName("invoiceDate")]
        public DateTime invoiceDate { get; set; }

        [JsonProperty("bookedInvoiceNumber")]
        [JsonPropertyName("bookedInvoiceNumber")]
        public int bookedInvoiceNumber { get; set; }

        [JsonProperty("orderNumber")]
        [JsonPropertyName("orderNumber")]
        public int orderNumber { get; set; }

        [JsonProperty("date")]
        [JsonPropertyName("date")]
        public string date { get; set; }

        [JsonProperty("currency")]
        [JsonPropertyName("currency")]
        public string currency { get; set; }

        [JsonProperty("exchangeRate")]
        [JsonPropertyName("exchangeRate")]
        public double exchangeRate { get; set; }

        [JsonProperty("netAmount")]
        [JsonPropertyName("netAmount")]
        public double netAmount { get; set; }

        [JsonProperty("netAmountInBaseCurrency")]
        [JsonPropertyName("netAmountInBaseCurrency")]
        public double netAmountInBaseCurrency { get; set; }

        [JsonProperty("grossAmount")]
        [JsonPropertyName("grossAmount")]
        public double grossAmount { get; set; }

        [JsonProperty("grossAmountInBaseCurrency")]
        [JsonPropertyName("grossAmountInBaseCurrency")]
        public double grossAmountInBaseCurrency { get; set; }

        [JsonProperty("vatAmount")]
        [JsonPropertyName("vatAmount")]
        public double vatAmount { get; set; }

        [JsonProperty("roundingAmount")]
        [JsonPropertyName("roundingAmount")]
        public double roundingAmount { get; set; }

        [JsonProperty("remainder")]
        [JsonPropertyName("remainder")]
        public double remainder { get; set; }

        [JsonProperty("remainderInBaseCurrency")]
        [JsonPropertyName("remainderInBaseCurrency")]
        public double remainderInBaseCurrency { get; set; }

        [JsonProperty("dueDate")]
        [JsonPropertyName("dueDate")]
        public string dueDate { get; set; }

        [JsonProperty("sent")]
        [JsonPropertyName("sent")]
        public string sent { get; set; }

        [JsonProperty("self")]
        [JsonPropertyName("self")]
        public string self { get; set; }
    }


}
