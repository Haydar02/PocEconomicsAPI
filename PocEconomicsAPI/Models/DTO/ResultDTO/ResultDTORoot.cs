using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PocEconimics.Models.DTO.ResultDTO
{
    public class ResultDTORoot
    {

        public string message { get; set; }

        public string logId { get; set; }

        public int httpStatusCode { get; set; }

        public string httpStatusMessage { get; set; }

        public List<ResultErrorDetailes> HeadErrors { get; set; }

        public List<ResultErrorDetailes> LineErrors { get; set; }


        public DateTime logTime { get; set; }

        //if status = 0 ok
        //if status = 3 Error 
        public int Status { get; set; }

       
    }
}
