using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Models.DTO.InvoiceDTO
{

        public class InvoiceCollectionRootDTO
    {
        [JsonProperty("collection")]
        [JsonPropertyName("collection")]
        public List<InvoiceCollectionDTO> collection { get; set; }


       


        [JsonProperty("self")]
            [JsonPropertyName("self")]
            public string self { get; set; }

        
        }
    
}
