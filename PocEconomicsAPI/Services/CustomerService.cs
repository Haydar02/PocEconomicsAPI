using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using PocEconimics.Helper;
using PocEconimics.Models;
using PocEconimics.Models.DTO.CustomerDTO;
using PocEconimics.Models.DTO.InvoiceDTO;
using PocEconimics.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PocEconomicsAPI.Models;
using System.Linq.Expressions;

namespace PocEconimics.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerAndSave(int customerNo, string license,
                                                      int type);

    }
    public class CustomerService : ICustomerService
    {
        private readonly IAPICustomerHandler _customerHandler;
        private readonly ICustomerRepositores _customerRepositores;
       


        public CustomerService(IAPICustomerHandler customerHandler, ICustomerRepositores customerRepositores)
        {
            _customerHandler = customerHandler;
            _customerRepositores = customerRepositores;
        }

        public async Task<Customer> GetCustomerAndSave(int customerNo, string license, 
                                                       int type)

        {
            try

            {
                CustomerDTORoot customerdto = await _customerHandler.GetCustomrDetailesFromEconomic(customerNo);

                bool existingCustomer = await _customerRepositores.CustomerExsist(customerNo, license);

                if (existingCustomer)
                {
                    throw new InvalidOperationException($"Customer {customerNo} is already registered");

                }

                if (customerdto != null)

                {
                    Customer customer = new Customer()
                    {
                        License = license,
                        customerNo = customerdto.customerNumber,
                        Type = type,
                        CompanyName = customerdto.name,
                        Address = customerdto.address,
                        Address2 = "", 
                        Postcode = customerdto.zip,
                        City = customerdto.city,
                        CountryCode = "",
                        ContactEmail = customerdto.email,
                        ContactPhone = "",
                        GLN = "",
                        Endpoint = "",
                        Vat = "",
                        Region = ""
                    };
                    await _customerRepositores.InsertCustomer(customer);

                  
                    return customer;
                }

                else
                {
                    throw new InvalidOperationException($"Failed to fetch customer from the e-conomic API. Customer ID: {customerNo}");

                    
                }
            }

            catch (Exception ex)

            {
                throw ex;
            }

        }
      


    }
}


