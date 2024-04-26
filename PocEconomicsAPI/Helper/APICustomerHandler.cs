using Newtonsoft.Json;
using PocEconimics.Models;
using PocEconimics.Models.DTO.CustomerDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PocEconimics.Helper
{
    public interface IAPICustomerHandler
    {
        Task<CustomerDTORoot> GetCustomrDetailesFromEconomic(int customerNo);
    }
    public class APICustomerHandler : IAPICustomerHandler
    {
       
        public async Task<CustomerDTORoot> GetCustomrDetailesFromEconomic(int customerNo)
        {
            string result = string.Empty;
            string endpoint = $"https://restapi.e-conomic.com/Customers/{customerNo}/?demo=true";
            string appSecretToken = "9jwyT7KFK7kLig1MYOMAMcFJrCYlvpNyPgFYK0gEo8I";
            string agreementGrantToken = "NA19Ho6qbZKrF0xLaiUH2jkzyfxnynOyLFRqD4ePNHE1";

            using (HttpClient client = new HttpClient())
            {
               // client.DefaultRequestHeaders.Add("X-AppSecretToken", appSecretToken);
               // client.DefaultRequestHeaders.Add("X-AgreementGrantToken", agreementGrantToken);

                try
                {
                    HttpResponseMessage response = await client.GetAsync(endpoint);
                    CustomerDTORoot Jsoncustomer = JsonConvert.DeserializeObject<CustomerDTORoot>(result);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                        var customerData = JsonConvert.DeserializeObject<CustomerDTORoot>(result);
                       
                        return customerData;
                    }

                    else
                    {
                        Console.WriteLine(response.StatusCode);
                         result = $"Error fetching customer details for ID {customerNo}";
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                  throw ex;
                }
            }
            


        }

       
       
    }
}
