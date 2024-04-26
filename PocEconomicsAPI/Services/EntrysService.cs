using Microsoft.EntityFrameworkCore;
using PocEconomicsAPI.Models;

namespace PocEconomicsAPI.Services
{
    public interface IEntryService
    {
     
        Task<DateTime> GetLastDownloadForCustomerAsync(int customerNo);

        Task CheckLastDownload(int customerNo, DateTime fromDate);
    }
    public class EntrysService : IEntryService

    {

        private readonly AppDbContext _context;

        public EntrysService(AppDbContext context)
        {
            _context = context;
        }

     

        public async Task<DateTime> GetLastDownloadForCustomerAsync(int customerNo)
        {
            try
            {
                var lastDownloaad = await _context.EntrysFeilds.AsNoTracking()
                    .Where(e => e.customerNo == customerNo)
                    .OrderByDescending(e => e.LastDownload)
                    .Select(e => e.LastDownload)
                    .FirstOrDefaultAsync();
               
                if(lastDownloaad != default(DateTime))
                {
                    return DateTime.Today.AddDays(-10);
                }
                return lastDownloaad;
               

            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while fetching last download data.", ex);
            }
        }
        public async Task CheckLastDownload(int customerNo, DateTime fromDate)
        {
            try
            {
                var entry = await _context.EntrysFeilds .FirstOrDefaultAsync(e => e.customerNo == customerNo);

                if (entry != null)
                {
                    entry.LastDownload = fromDate;

                }
                else
                {
                    entry = new EntrysFeild
                    {
                        customerNo = customerNo,
                        LastDownload = DateTime.Now
                    };
                    _context.EntrysFeilds.Add(entry);
                }
                await _context.SaveChangesAsync();
            
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error occurred while updating last download", ex);
                
            }
        }

        
    }
}
