using Microsoft.EntityFrameworkCore;

using PocEconimics.Models;
using PocEconomicsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocEconimics.Repository
{
    public interface ICustomerRepositores
    {
        Task InsertCustomer(Customer customer);
        Task<bool> CustomerExsist(int customerNo, string license);
    }
    public class CustomerRepositores : ICustomerRepositores
    {

        private AppDbContext _context;

        public CustomerRepositores(AppDbContext context)
        {
            _context = context ;
        }

        public async Task InsertCustomer(Customer customer)
        {

            try
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting customer into the database : {ex.Message}");
                throw ex;
            }

        }
        public async Task<bool> CustomerExsist(int customerNo,string license)
        {
            try
            {
                return await _context.Customers.AnyAsync(c => c.customerNo == customerNo && c.License == license);
            }
            catch (Exception ex)
            {
                throw new Exception($" Error fetching customer by ID {ex.ToString()}");
                throw ex;
            }
        }

    }
}
