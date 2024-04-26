
using Newtonsoft.Json;
using PocEconimics.Helper;
using PocEconimics.Models.DTO.InvoiceDTO;
using PocEconomicsAPI.Models;
using PocEconomicsAPI.Repository;
using PocEconomicsAPI.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocEconimics.Services
{
    public interface IinvoiceService
    {
        Task<List<InvoiceCollectionDTO>> GetInvoiceList(DateTime fromDate,  int customerNo);
        // Task DownloadInvoices(List<InvoiceCollectionDTO> invoices);
        Task DownloadInvoices(DateTime fromDate, int customerNo);
        Task<string> DownloadInvoiceById(int invoiceNumber);
        Task<InvoiceDTORoot> GetInvoiceById(int id);
       

    }
    public class InvoiceService : IinvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IEntryService _entryService;
        private readonly ICSVFormatService _csvFormatService;

        public InvoiceService(IInvoiceRepository invoiceRepository, IEntryService entryService,ICSVFormatService csvFormatService)
        {
            _invoiceRepository = invoiceRepository;
            _entryService = entryService;
            _csvFormatService = csvFormatService;
        }

        public async Task<List<InvoiceCollectionDTO>> GetInvoiceList(DateTime fromDate, int customerNo)
        {

            try
            {
                APIRequestHandler aPIRequestHandler = new APIRequestHandler();
                var now = DateTime.Now;
                string JsonListOfInvoices = await aPIRequestHandler.GetInvoiceList(fromDate, now, customerNo);

                if (string.IsNullOrEmpty(JsonListOfInvoices))
                {
                    Console.WriteLine("Empty Json Response. Check API request");
                    throw new EntryPointNotFoundException("Error Calling Endpoint");
                }

                var invoiceCollectionroot = JsonConvert.DeserializeObject<InvoiceCollectionRootDTO>(JsonListOfInvoices);

                if (invoiceCollectionroot == null)
                {
                    throw new DirectoryNotFoundException("Collection not parsed");
                }
                var invoiceList = invoiceCollectionroot.collection;

                if (invoiceList != null)
                {
                    return invoiceList;
                }
                return invoiceList ?? new List<InvoiceCollectionDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }

        public async Task DownloadInvoices(DateTime fromDate, int customerNo)
        {
            try
            {               

               var now = DateTime.Now;
                Log.Information("Starting invoice download process");
           
                var invoices = await GetInvoiceList(fromDate, customerNo);

               DateTime lastDownload = await _entryService.GetLastDownloadForCustomerAsync(customerNo);
               

                await _entryService.CheckLastDownload(customerNo, lastDownload);

                 
                Log.Information("Found {InvoiceCount} invoices to process.", invoices.Count);


                foreach (var invoice in invoices)
                
                {
                    int invoiceNumber = invoice.bookedInvoiceNumber;
                    Console.WriteLine(invoiceNumber);
                    string filename = await DownloadInvoiceById(invoiceNumber);
                   
                   
                    bool invoiceExists = await _invoiceRepository.AnyInvoicesAsync(invoice.bookedInvoiceNumber);
                    if (!invoiceExists)
                    {
                        
                        var newEntry = new FileQueueInbound
                        {
                            TransportCode = "Webservice",
                            SubEntryNo = 0,
                            ProfileId = 0,
                            Status = 0,
                            DocumentType = "JSON",
                            DocumentNo = invoice.bookedInvoiceNumber.ToString(),
                            CreatedOn = DateTime.UtcNow,
                            ModifiedOn = DateTime.UtcNow,
                            FileSize = 0,
                            FileFormat = "JSON",
                            IdentifiedFormat = "",
                            Codepage = "",
                            ReceiverLicense = "",
                            ReceiverName = "",
                            SenderLicense = "",
                            SenderName = "",
                            DocumentPath = filename,
                            Error = false
                        };
                       
                        await _invoiceRepository.Insert(newEntry);
                        await _invoiceRepository.SaveChangesAsync();
                      

                        Log.Information("Invoices download process completed  successfuly");
                       
                       await _csvFormatService.DownloadCSVInvoice((int)newEntry.Id);
                    }

                }
               
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred during invoice download: {ex.Message}");
                
            }
        }

        public async Task<string> DownloadInvoiceById(int invoiceNumber)
        {
            string root = @"C:\\Temp\\downloadinvoices";
            APIRequestHandler aPIRequest = new APIRequestHandler();
            try
            {
                string invoiceJson = await aPIRequest.GetInvoiceByid(invoiceNumber);

                if (!string.IsNullOrEmpty(invoiceJson))
                {

                    string fileName = ($"Invoice_{invoiceNumber}.json");

                    string path = Path.Combine(root, fileName);
                    System.IO.File.WriteAllText(path, invoiceJson);

                    Console.WriteLine($"Invoice {invoiceNumber} downloaded and saved ");

                    return path;
                }
                else

                {
                    throw new InvalidOperationException($"Failed to download invoice {invoiceNumber}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<InvoiceDTORoot> GetInvoiceById(int id)
        {
            APIRequestHandler aPIRequestHandler = new APIRequestHandler();
            string jsonInvoice = await aPIRequestHandler.GetInvoiceByid(id);

            InvoiceDTORoot invoice = JsonConvert.DeserializeObject<InvoiceDTORoot>(jsonInvoice);

            return invoice;
        }
      
    }
}
