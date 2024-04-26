using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using PocEconimics.Helper;
using PocEconimics.Models.DTO.InvoiceDTO;
using PocEconomicsAPI.Models;
using System.Collections.Generic;

namespace PocEconomicsAPI.Repository
{
    public interface IInvoiceRepository
    {
     
        Task<bool> AnyInvoicesAsync( int bookedInvoiceNumber);

        Task Insert(FileQueueInbound fileQueueInbound);
      
        Task SaveChangesAsync();
    }
    public class InvoiceRepositores : IInvoiceRepository
    {
        private readonly IAPIRequestHandler _apiRequestHandler;
        private readonly AppDbContext _appDbContext;

        public InvoiceRepositores(IAPIRequestHandler apiRequestHandler, AppDbContext appDbContext)
        {
            _apiRequestHandler = apiRequestHandler;
            _appDbContext = appDbContext;
        }


        public async Task Insert(FileQueueInbound fileQueueInbound)
        {
            try
            {
                if(fileQueueInbound != null)
                {
                    _appDbContext.FileQueueInbounds.Add(fileQueueInbound);
                }

            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error occurred while inserting entry", ex);

            }


        }

        public async Task SaveChangesAsync()
        {
           await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> AnyInvoicesAsync( int DocumentNo)
        {
            return await _appDbContext.FileQueueInbounds
              .AnyAsync(f =>  f.DocumentNo == DocumentNo.ToString());
        }

        



    }
}
