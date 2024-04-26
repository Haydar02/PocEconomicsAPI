using Microsoft.EntityFrameworkCore;
using PocEconimics.Models.DTO.InvoiceDTO;
using PocEconomicsAPI.Models;

namespace PocEconomicsAPI.Repository
{
    public interface IFileQueueInboundRepositores
    {
        Task<List<FileQueueInbound>> GetDownloadedInvoiceAsync();
        Task<FileQueueInbound> GetFileQueueInboundById(long Id);
        Task CheckDownloadStatus(long Id);
        //Task<FileQueueInbound> GetByCompositKeys(long Id, string transportCode, int SubEntryNo, int profileId);



    }
    public class FileQueueInboundRepositores : IFileQueueInboundRepositores
    {
       private readonly AppDbContext _appDbContext;

       public FileQueueInboundRepositores(AppDbContext appDbContext)
        {

            _appDbContext = appDbContext;
        }

        public async Task<List<FileQueueInbound>> GetDownloadedInvoiceAsync()
        {
            return await _appDbContext.FileQueueInbounds
                .Where(f => f.Status == 1)
                .ToListAsync();     
        }

        public async Task<FileQueueInbound> GetFileQueueInboundById(long Id)
        {
            return await _appDbContext.FileQueueInbounds.FirstOrDefaultAsync(f => f.Id == Id);

        }

        public async Task CheckDownloadStatus(long Id)
        {
            try
            {
                var result = await _appDbContext.FileQueueInbounds.AnyAsync(
                     p => p.Id == Id);
                     
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
       
        //public async Task<FileQueueInbound> GetByCompositKeys(long Id, string transportCode, int SubEntryNo, int profileId)
        //{
        //    var result = await _appDbContext.FileQueueInbounds.FirstOrDefaultAsync(
        //        p => p.Id == Id &&
        //        p.TransportCode == transportCode &&
        //        p.SubEntryNo == SubEntryNo &&
        //        p.ProfileId == profileId);
        //    return result ?? throw new Exception($"No FileQueueInbound entry found with the provided composite keys: Id = {Id} TransportCode = {transportCode} SubEntry1no={SubEntryNo} ProfileId = {profileId}");
        //}

    }
}

