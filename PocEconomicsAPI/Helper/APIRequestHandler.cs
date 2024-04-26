using Newtonsoft.Json;
using PocEconimics.Models;
using PocEconimics.Models.DTO.InvoiceDTO;
using PocEconimics.Models.DTO.OrderDTO;
using PocEconimics.Models.DTO.ResultDTO;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocEconimics.Helper
{
    public interface IAPIRequestHandler
    {
        Task<string> GetInvoiceByid(int id);
        Task<string> GetInvoiceList(DateTime fromDate, DateTime toDate, int customerNo);
        Task<ResultDTORoot> PostOrder(OrderDTORoot order);
        ResultDTORoot HandleErrors(string errorMessage);

        public int ExtractHttpStatusCode(string errorMessage);
        public List<ResultErrorDetailes> HandleSchemavalidation(string Errorresponse);
        public List<ResultErrorDetailes> HandleErrorHead(string Errorresponse);
       public List<ResultErrorDetailes> HandleErrorLines(string Errorresponse);

        public string GetHttpMessage(int httpStatusCode);


        }
    public class APIRequestHandler : IAPIRequestHandler
    {
        public async Task<string> GetInvoiceByid(int id)
        {
            string result = string.Empty;
            string endpoint = $"https://restapi.e-conomic.com/invoices/booked/{id}?demo=true";
            string appSecretToken = "9jwyT7KFK7kLig1MYOMAMcFJrCYlvpNyPgFYK0gEo8I";
            string agreementGrantToken = "NA19Ho6qbZKrF0xLaiUH2jkzyfxnynOyLFRqD4ePNHE1";

            using (HttpClient client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Add("X-AppSecretToken", appSecretToken);
                //client.DefaultRequestHeaders.Add("X-AgreementGrantToken", agreementGrantToken);
               

                try
                {
                    HttpResponseMessage response = await client.GetAsync(endpoint);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                        
                    }
                }
                catch (Exception ex) 
                {
                    throw new Exception($"fejl ved at hente faktura fra e-conomic. statuskode :");
                   
                   
                    return null;
                }
            }

            return result;
        }

        public async Task<string> GetInvoiceList( DateTime fromDate, DateTime toDate, int customerNo)
        {
            string from = fromDate.ToString("yyyy-MM-dd");
            string to = toDate.ToString("yyyy-MM-dd");
            string result = string.Empty;
            string endpoint = $"https://restapi.e-conomic.com/invoices/booked?filter=date$gte:{from}$and:date$lte:{to}$and:customer.customerNumber$eq:{customerNo}&demo=true";
            string appSecretToken = "9jwyT7KFK7kLig1MYOMAMcFJrCYlvpNyPgFYK0gEo8I";
            string agreementGrantToken = "NA19Ho6qbZKrF0xLaiUH2jkzyfxnynOyLFRqD4ePNHE1";

            using (HttpClient client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Add("X-AppSecretToken", appSecretToken);
                //client.DefaultRequestHeaders.Add("X-AgreementGrantToken", agreementGrantToken);

                try
                {
                    HttpResponseMessage response = await client.GetAsync(endpoint);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                    return null;                    
                }
            }
            return result;
        }


        public async Task<ResultDTORoot> PostOrder(OrderDTORoot order)
        {
          
            string endpoint = "https://restapi.e-conomic.com/orders/drafts?demo=true";
            string appSecretToken = "9jwyT7KFK7kLig1MYOMAMcFJrCYlvpNyPgFYK0gEo8I";
            string agreementGrantToken = "NA19Ho6qbZKrF0xLaiUH2jkzyfxnynOyLFRqD4ePNHE1";

            using (HttpClient client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Add("X-AppSecretToken", appSecretToken);
                //client.DefaultRequestHeaders.Add("X-AgreementGrantToken", agreementGrantToken);

                try
                {
                    string JsonOrder = JsonConvert.SerializeObject(order);

                    StringContent content = new StringContent(JsonOrder, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(endpoint, content);

                    ResultDTORoot dTORoot = new ResultDTORoot();

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(result);
                        ResultDTORoot resultDTO = JsonConvert.DeserializeObject<ResultDTORoot>(result);
                        
                        resultDTO.Status = 0;

                        dTORoot.httpStatusCode = (int)response.StatusCode;
                        dTORoot.message = "Requert was successful";
                       
                        return resultDTO;
                    }
                    else
                    {
                      
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        if(!string.IsNullOrEmpty(errorMessage))
                        {
                            ResultDTORoot resultDTO = HandleErrors(errorMessage);

                            return resultDTO;
                        }
                        else
                        {
                            ResultDTORoot resultDTO = new ResultDTORoot();
                            resultDTO.Status = 1;
                            resultDTO.message = "IsEmpty";
                            return resultDTO;
                        }
                        
                    }
                    
                    
                }
                catch (HttpRequestException ex)
                {

                    throw new Exception($"Fejl ved HTP-anmodning : {ex.Message}");

                    ResultDTORoot resultDTO = new ResultDTORoot();
                    resultDTO.Status = 1;
                    resultDTO.message = $"Fejl ved HTP-anmodning : {ex.Message}";
                    return resultDTO;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public ResultDTORoot HandleErrors(string errorMessage)
        {
            ResultDTORoot resultDTORoot = new ResultDTORoot();
            resultDTORoot.Status = 0;
            int httpStatusCode = ExtractHttpStatusCode(errorMessage);
            resultDTORoot.httpStatusCode = httpStatusCode;

            resultDTORoot.httpStatusMessage = GetHttpMessage(httpStatusCode);

            if (errorMessage.ToUpper().Contains("Schema validation failed.".ToUpper()))
            {
                resultDTORoot.HeadErrors = HandleSchemavalidation(errorMessage);
            }
            else
            {
                var headerrors = HandleErrorHead(errorMessage);
                var lineErrors = HandleErrorLines(errorMessage);

                resultDTORoot.HeadErrors = headerrors;
                resultDTORoot.LineErrors = lineErrors;

            }

            return resultDTORoot;
        }

        public int ExtractHttpStatusCode(string errorMessage)
        {
            try
            {
                var json = JsonObject.Parse(errorMessage);
                var statusCodeToken = json["httpStatusCode"];
                if (statusCodeToken != null && int.TryParse(statusCodeToken.ToString(), out var statusCode))
                {
                    return statusCode;
                }
                return 400;
            }
            catch (JsonException)
            {
                return 400;
            }
        }

        public List<ResultErrorDetailes> HandleSchemavalidation(string Errorresponse)
        {
            var errorlist = new List<ResultErrorDetailes>();
            var errors = JsonConvert.DeserializeObject<SchemavalidationDTOResult>(Errorresponse);

            foreach (var error in errors.errors) {
                ResultErrorDetailes resultErrorDetailes = new ResultErrorDetailes()
                {
                    errorMessage = error.ToString()
                };
                errorlist.Add(resultErrorDetailes);
            }

            return errorlist;

        }


        public List<ResultErrorDetailes> HandleErrorHead(string Errorresponse)
        {
            var HeadErrors = new List<ResultErrorDetailes>();

            var dynamicsObject = JsonConvert.DeserializeObject<dynamic>(Errorresponse);

            var lineItems = dynamicsObject.errors;

            foreach (var lineItem in lineItems)
            {
                string errorName = lineItem.Name.ToString();

                if (errorName.ToUpper() != "LINES")
                { 
                    if (errorName != "arrayIndex")
                    {
                        var errors = lineItem.Value.errors;
                        foreach (var err in errors)
                        {
                            ResultErrorDetailes resultErrorDetailes = new ResultErrorDetailes
                            {
                                propertyName = err.propertyName,
                                developerHint = err.developerHint,
                                errorCode = err.errorCode,
                                errorMessage = err.errorMessage,
                                inputValue = err.inputValue,
                             

                            };

                            HeadErrors.Add(resultErrorDetailes);
                        }
                    }

                  
                }

            }

            Console.WriteLine(HeadErrors.ToString());
            return HeadErrors;
        }

        public List<ResultErrorDetailes> HandleErrorLines(string Errorresponse)
        {

            var LineErrors = new List<ResultErrorDetailes>();
            var dynamicsObject = JsonConvert.DeserializeObject<dynamic>(Errorresponse);

            var lineItems = dynamicsObject.errors.lines.items;

            foreach (var lineItem in lineItems)
            {
                int lineid = 0;
                foreach (var errorname in lineItem)
                {

                    if (errorname.Name == "arrayIndex")
                    {

                        lineid = errorname.Value;

                    }
                    if (errorname.Name != "arrayIndex")
                    {
                        var errors = errorname.Value.errors;


                        foreach (var err in errors)
                        {
                            ResultErrorDetailes resultErrorDetailes = new ResultErrorDetailes
                            {
                                propertyName = err.propertyName,
                                developerHint = err.developerHint,
                                errorCode = err.errorCode,
                                errorMessage = err.errorMessage,
                                inputValue = err.inputValue,
                                lineId = lineid,

                            };

                            LineErrors.Add(resultErrorDetailes);
                        }
                    }
                }

            }
            Console.WriteLine(LineErrors.ToString());
            return LineErrors;


        }

        public string GetHttpMessage(int httpStatusCode)
        {
                switch (httpStatusCode)
                {
                    case 200: return "Order posted successfully OK";break;
                    case 201: return "Created";break;
                    case 204: return " Not Content"; break;
                    case 400: return "Bad Request"; break;
                    case 401: return "Unauthorized"; break;
                    case 403: return "Forbidden"; break;
                    case 404: return "Not Found"; break;
                    case 405: return "Method Not Allowed"; break;
                    case 415: return "Unsupported Media Type"; break;
                    case 500: return "Internal Server"; break;
                    case 501: return "Not Implemented"; break;
                    default: return $"Unexpected HTTP status code : {httpStatusCode}"; break;
                }
            return httpStatusCode.ToString();
        }

       
    }
}
