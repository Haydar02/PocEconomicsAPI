using Newtonsoft.Json;
using PocEconimics.Helper;
using PocEconimics.Models.DTO.InvoiceDTO;
using PocEconomicsAPI.Models;
using PocEconomicsAPI.Models.DTO.InhouseData;
using PocEconomicsAPI.Repository;
using Serilog;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

namespace PocEconomicsAPI.Services
{
    public interface ICSVFormatService
    {
        Task DownloadCSVInvoice(long Id);

        Task<string> SaveCSVToFile(string csvData, string fileName, string root);
        string GenerateFileName(long Id);
        Task PopulateFileWithNxMData(Inhouse nxMData, string filePath);

    }
    public class CSVFormatService : ICSVFormatService
    {
        private readonly IInvoiceRepository _rep;
        private readonly IFileQueueInboundRepositores _inboundRepositores;


        public CSVFormatService(IInvoiceRepository rep, IFileQueueInboundRepositores inboundRepositores)
        {
            _rep = rep;
            _inboundRepositores = inboundRepositores;
        }


        public async Task DownloadCSVInvoice(long Id)
        {
            try
            {
                var fileData = await _inboundRepositores.GetFileQueueInboundById(Id);
                if (fileData != null)
                {
                    string invoiceContent = File.ReadAllText(fileData.DocumentPath);
                    var invoiceData = JsonConvert.DeserializeObject<InvoiceDTORoot>(invoiceContent);
                    var data = INvoiceToInhousData(invoiceData);
                    var inhouseData = PopulateFileWithNxMData(data, fileData.DocumentPath);
                    string fileName = GenerateFileName(fileData.Id);
                    string fileRoot = @"C:\\Temp\\CSVfiler";
                    string filePath = await SaveCSVToFile(invoiceContent, fileName, fileRoot);
                    Log.Information($"Invoice is converted to CSV format : {fileName}");
                }

            }
            catch (Exception ex)
            {
                Log.Error($"Error occurred : {ex.Message}");
                throw ex;
            }
        }

        public async Task<string> SaveCSVToFile(string csvData, string fileName, string root)
        {
            // string root = @"C:\\Temp\\CSVFiler";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            string fileRoot = Path.Combine(root, fileName);
            await File.WriteAllTextAsync(fileRoot, csvData);
            return fileRoot;

        }

        public string GenerateFileName(long Id)
        {
            string fileName = $"{Id}";


            return fileName;

        }


        public async Task PopulateFileWithNxMData(Inhouse nxMData, string filePath)
        {


            using var writer = new StreamWriter(filePath);


            await writer.WriteLineAsync(CreateCsvLine("HEAD1_001", nxMData.HEADER.HEAD1, nxMData.HEADER.AGREEMENTNO, nxMData.HEADER.SEND_DOC_EDI, nxMData.HEADER.SEND_DOC_PDF, nxMData.HEADER.FORMAT, nxMData.HEADER.DOCUMENTTYPE, nxMData.HEADER.DOCUMENTNO, nxMData.HEADER.DIRECTION, nxMData.HEADER.DOCUMENT_UUID, nxMData.HEADER.PROFILE, nxMData.HEADER.INTERCHANGE_ID, nxMData.HEADER.MESSAGE_ID, nxMData.HEADER.INTERCHANGE_SENDER, nxMData.HEADER.INTERCHANGE_RECEIVER, nxMData.HEADER.TEST_DOCUMENT));

            // Header's Subsections
            await writer.WriteLineAsync(CreateCsvLine("HEADDATE", nxMData.HEADER.HEADDATE.DOC_DATE, nxMData.HEADER.HEADDATE.SHIPMENT_DATE, nxMData.HEADER.HEADDATE.ORDER_DATE, nxMData.HEADER.HEADDATE.REQ_DEL_DATE, nxMData.HEADER.HEADDATE.PROM_DEL_DATE, nxMData.HEADER.HEADDATE.EXP_DEL_DATE, nxMData.HEADER.HEADDATE.EXP_REC_DATE, nxMData.HEADER.HEADDATE.PLAN_DEL_DATE, nxMData.HEADER.HEADDATE.DUE_DATE));
            await writer.WriteLineAsync(CreateCsvLine("HEAD2", nxMData.HEADER.HEAD2.CURRENCY, nxMData.HEADER.HEAD2.TOTAL_AMOUNT_INCL_VAT, nxMData.HEADER.HEAD2.TOTAL_AMOUNT_EX_VAT, nxMData.HEADER.HEAD2.PAYMENTMETH, nxMData.HEADER.HEAD2.SHIPMENTMETH, nxMData.HEADER.HEAD2.PREFER_SHIPMENTMETH));
            await writer.WriteLineAsync(CreateCsvLine("HEADBANK", nxMData.HEADER.HEADBANK.PAYM_IDENT_TYPE, nxMData.HEADER.HEADBANK.PAYM_IDENT_ID, nxMData.HEADER.HEADBANK.BANK_NAME, nxMData.HEADER.HEADBANK.BANK_BRANCH, nxMData.HEADER.HEADBANK.BANK_ACCOUNT, nxMData.HEADER.HEADBANK.IBAN, nxMData.HEADER.HEADBANK.SWIFT));
            if (nxMData.HEADER.HEADCONTACT != null)
            {
                await writer.WriteLineAsync(CreateCsvLine("HEADCONTACT", nxMData.HEADER.HEADCONTACT.Tech_Email, nxMData.HEADER.HEADCONTACT.tech_Name, nxMData.HEADER.HEADCONTACT.tech_Phone));
            }
            else
            {
                await writer.WriteLineAsync("HEADCONTACT;;;");
            }
            foreach (var custom in nxMData.HEADER.HEADCUSTOM)
                await writer.WriteLineAsync(CreateCsvLine("HEADCUSTOM", custom.IDENT, custom.VALUE, custom.TYPE));
            foreach (var party in nxMData.HEADER.HEADPARTY)
                await writer.WriteLineAsync(CreateCsvLine("HEADPARTY", party.PARTY_TYPE, party.ID_ENDPOINT_IDENT, party.ID_ENDPOINTTYPE, party.ID_OTHER_IDENT, party.ID_VAT_NBR, party.ID_ORG_NBR, party.CONTACT_ID, party.CONTACT_NAME, party.CONTACT_PHONE, party.CONTACT_EMAIL, party.CONTACT_FAX, party.NAME, party.NAME2, party.ADDRESS, party.ADDRESS2, party.POST_CODE, party.CITY, party.COUNTRY_REGION, party.ADR_POSTBOX, party.ADR_FLOOR, party.ADR_STREETNAME, party.ADR_BUILDING_NBR, party.ADR_DEPARTMENT, party.ADR_REGION, party.ADR_DISTRICT));

            // Lines
            foreach (var line in nxMData.liens)
            {
                await writer.WriteLineAsync(CreateCsvLine("LINEINFO", line.DOCUMENTTYPE, line.DOCUMENTNO, line.LINE_ID));
                await writer.WriteLineAsync(CreateCsvLine("LINEITEM", line.LINEITEM.ITEM_NO_STANDARD, line.LINEITEM.ITEM_MANUFACT_ITEM_NO, line.LINEITEM.ITEM_VENDOR_ITEM_NO, line.LINEITEM.ITEM_SELLERS_ITEM_NO, line.LINEITEM.DATE_EXPECT_RECEIPT, line.LINEITEM.BACKORDER, line.LINEITEM.DESCRIPTION, line.LINEITEM.LINE_STATUS, line.LINEITEM.DESCRIPTION2));
                await writer.WriteLineAsync(CreateCsvLine("LINEAMOUNT", line.LINEAMOUNT.UNIT_PRICE_SALE, line.LINEAMOUNT.UNIT_PRICE_COST, line.LINEAMOUNT.VAT_AMOUNT, line.LINEAMOUNT.AMOUNT_EX_VAT, line.LINEAMOUNT.AMOUNT_INCL_VAT, line.LINEAMOUNT.VAT_PCT, line.LINEAMOUNT.DISCOUNT_AMOUNT));
                await writer.WriteLineAsync(CreateCsvLine("LINEQTY", line.LINEQTY.UNIT_OF_MEAS, line.LINEQTY.QTY_DOCUMENT, line.LINEQTY.QTY_BACKORDER, line.LINEQTY.QTY_PER_UNIT_MEAS, line.LINEQTY.QTY_TOTAL_SHIPPED, line.LINEQTY.QTY_ORIG_ORDER, line.LINEQTY.VARIANT));
                if (line.LINEREF != null)
                {
                    await writer.WriteLineAsync(CreateCsvLine("LINEREF", line.LINEREF.DOC_REF_NO, line.LINEREF.DOC_REF_LINE_NO, line.LINEREF.PACK_REF_NO, line.LINEREF.INVOICE_REF, line.LINEREF.INVOICE_REF_LINE_NO));
                }
                else
                {
                    await writer.WriteLineAsync("LINEREF;;;;;");
                }
                foreach (var custom in line.LINECUSTOM)
                    await writer.WriteLineAsync(CreateCsvLine("LINECUSTOM", custom.FIELDCODE, custom.FIELDTYPE, custom.VALUE));
            }

            // Footer
            if (nxMData.Footer != null)
            {
                await writer.WriteLineAsync(CreateCsvLine("FOOT1", nxMData.Footer.FOOT1.NO_OF_LINES, nxMData.Footer.FOOT1.NO_OF_QTY, nxMData.Footer.FOOT1.TOTAL_AMOUNT, nxMData.Footer.FOOT1.TOTAL_LINE_AMOUNT, nxMData.Footer.FOOT1.ROUNDOFF, nxMData.Footer.FOOT1.TOTAL_DISC_AMOUNT, nxMData.Footer.FOOT1.TOTAL_FEE, nxMData.Footer.FOOT1.TOTAL_TAXBASE_AMOUNT, nxMData.Footer.FOOT1.TOTAL_TAX_AMOUNT));
                foreach (var tax in nxMData.Footer.FOOTTAXLIST)
                    await writer.WriteLineAsync(CreateCsvLine("FOOTTAXLIST", tax.TAX_BASE, tax.TAX_AMOUNT, tax.TAX_TYPE, tax.TAX_RATE, tax.TAX_CATEGORY));
            }
            else
            {
                await writer.WriteLineAsync("FOOT1;;;;;;;;;");
                await writer.WriteLineAsync("FOOTTAXLIST;;;;;");
            }


        }


        public static string CreateCsvLine(params object[] values)
        {
            return string.Join(';', values.Select(v => v?.ToString() ?? string.Empty));
        }


        public static Inhouse INvoiceToInhousData(InvoiceDTORoot invoice)

        {

            var header = new Header
            {


                AGREEMENTNO = invoice.bookedInvoiceNumber.ToString(),
                SEND_DOC_EDI = true,
                SEND_DOC_PDF = false,
                FORMAT = "",
                DOCUMENTTYPE = invoice.orderNumber.ToString(),
                DIRECTION = "outbound",
                DOCUMENT_UUID = Guid.NewGuid().ToString(),
                PROFILE = "",
                INTERCHANGE_ID = "",
                MESSAGE_ID = "",
                INTERCHANGE_SENDER = "",
                INTERCHANGE_RECEIVER = "",
                HEADDATE = new HeadDate
                {
                    DOC_DATE = DateTime.Parse(invoice.date),
                    SHIPMENT_DATE = null,
                    ORDER_DATE = null,
                    REQ_DEL_DATE = null,
                    PROM_DEL_DATE = null,
                    EXP_DEL_DATE = null,
                    PLAN_DEL_DATE = null,
                    DUE_DATE = DateTime.Parse(invoice.dueDate),
                },
                HEAD2 = new Head2
                {
                    CURRENCY = invoice.currency,
                    TOTAL_AMOUNT_INCL_VAT = invoice.netAmount,
                    TOTAL_AMOUNT_EX_VAT = invoice.grossAmount,
                    PAYMENTMETH = "",
                    SHIPMENTMETH = "",
                    PREFER_SHIPMENTMETH = "",
                    Response_Status = ""

                },
                HEADBANK = new HeadBank
                {
                    PAYM_IDENT_TYPE = "",
                    PAYM_IDENT_ID = "",
                    BANK_NAME = "",
                    BANK_BRANCH = "",
                    BANK_ACCOUNT = "",
                    IBAN = "",
                    SWIFT = ""
                },
                HEADCONTACT = new HeadContact
                {
                    Tech_Email = "exempel@.com",
                    tech_Name = "XXXXXX",
                    tech_Phone = "+1234567898"
                },
                HEADCUSTOM = new List<HeadCustom>
                 {
                     new HeadCustom {
                     IDENT = "",
                     VALUE = invoice.paymentTerms.name,
                     TYPE = ""
                     }
                 },
                HEADPARTY = new List<HeadParty>
                 { new HeadParty{
                     PARTY_TYPE = "BILL-TO",
                     ID_ENDPOINT_IDENT = invoice.recipient.name,
                     ID_ENDPOINTTYPE = "",
                     ID_OTHER_IDENT = "",
                     ID_VAT_NBR =invoice.recipient.ean.ToString(),
                     ID_ORG_NBR = "",
                     CONTACT_ID = "",
                     CONTACT_NAME = "",
                     CONTACT_PHONE = "",
                     CONTACT_EMAIL = "",
                     CONTACT_FAX = "",
                     NAME = "",
                     NAME2 = "",
                     ADDRESS = invoice.recipient.address,
                     ADDRESS2 = "",
                     POST_CODE = invoice.recipient.zip,
                     CITY = invoice.recipient.city,
                     COUNTRY_REGION = invoice.recipient.country,
                     ADR_POSTBOX = "",
                     ADR_FLOOR = "",
                     ADR_STREETNAME = "",
                     ADR_BUILDING_NBR = "",
                     ADR_DEPARTMENT = "",
                     ADR_REGION = "",
                     ADR_DISTRICT = ""
                 }

              }
            };




            HeadREF HeadRef = new HeadREF
            {
                vendor_Ref = "",
                customrt_Ref = invoice.customer.ToString(),
                pack_Ref = "",
                priceList_Ref = "",
                relation_Invoice_No = "",
                doc_Ref_No = ""
            };
            HeadMail HeadMail = new HeadMail
            {
                Mail_ORD_RESP = "",
                MAIL_INV = "",
                MAIL_SHIP = ""
            };

            HeadParty headParty = new HeadParty
            {
                PARTY_TYPE = "BILL-TO",
                ID_ENDPOINT_IDENT = invoice.recipient.name,
                ID_ENDPOINTTYPE = "",
                ID_OTHER_IDENT = "",
                ID_VAT_NBR = "",
                ID_ORG_NBR = "",
                CONTACT_ID = "",
                CONTACT_NAME = "",
                CONTACT_PHONE = "",
                CONTACT_EMAIL = "",
                CONTACT_FAX = "",
                NAME = invoice.customer.customerNumber.ToString(),
                NAME2 = "",
                ADDRESS = invoice.recipient.address,
                ADDRESS2 = "",
                POST_CODE = invoice.recipient.zip,
                CITY = invoice.recipient.city,
                COUNTRY_REGION = invoice.recipient.country,
                ADR_POSTBOX = "",
                ADR_FLOOR = "",
                ADR_STREETNAME = "",
                ADR_BUILDING_NBR = "",
                ADR_DEPARTMENT = "",
                ADR_REGION = "",
                ADR_DISTRICT = ""
            };


            var lines = invoice.lines.Select(Line => new Line
            {
                DOCUMENTTYPE = Line.sortKey.ToString(),
                DOCUMENTNO = "",
                LINE_ID = "",
                LINEITEM = new LineItem
                {
                    ITEM_NO_STANDARD = Line.description,
                    ITEM_MANUFACT_ITEM_NO = "",
                    ITEM_VENDOR_ITEM_NO = "",
                    ITEM_SELLERS_ITEM_NO = Line.product.productNumber,
                    DATE_EXPECT_RECEIPT = DateTime.Parse(invoice.date),
                    BACKORDER = "no",
                    DESCRIPTION = $"{Line.description} with {Line.vatRate}% VAT",
                    LINE_STATUS = "",
                    DESCRIPTION2 = ""


                },
                LINEAMOUNT = new LineAmount
                {
                    UNIT_PRICE_SALE = Line.totalNetAmount,
                    UNIT_PRICE_COST = 0.00,
                    VAT_AMOUNT = 0.00,
                    AMOUNT_EX_VAT = 0.00,
                    AMOUNT_INCL_VAT = 0.00,
                    VAT_PCT = 0.00,
                    DISCOUNT_AMOUNT = 0.0

                },
                LINEQTY = new LineQty
                {
                    UNIT_OF_MEAS = 0.000,
                    QTY_DOCUMENT = 0.00,
                    QTY_BACKORDER = 0.00,
                    QTY_TOTAL_SHIPPED = 0.00,
                    VARIANT = "STK",
                    QTY_ORIG_ORDER = 0.00,
                    QTY_PER_UNIT_MEAS = 0.00

                },
                LINEREF = new LineRef
                {
                    INVOICE_REF = 0,
                    PACK_REF_NO = 0,
                    DOC_REF_LINE_NO = 0,
                    INVOICE_REF_LINE_NO = 0,
                    DOC_REF_NO = 0
                },
                LINECUSTOM = new List<LineCustom> { new LineCustom
                    {
                        FIELDCODE="",
                        VALUE ="",
                        FIELDTYPE = ""
                    }
                    }
            }).ToList();


            var footer = new Footer
            {
                FOOT1 = invoice.lines.Select(line => new Foot1
                {

                    NO_OF_LINES = line.lineNumber ,
                    NO_OF_QTY = line.quantity,
                    TOTAL_AMOUNT = 0.0000,
                    TOTAL_LINE_AMOUNT = 0.000,
                    ROUNDOFF = 0.0,
                    TOTAL_DISC_AMOUNT = 0.0,
                    TOTAL_FEE = 0.0,
                    TOTAL_TAXBASE_AMOUNT = 0.0,
                    TOTAL_TAX_AMOUNT = 0.00
                }),
                FOOTTAXLIST = invoice.lines.Select(line => new List<FootTaxList>
                {
                    new FootTaxList
                    {
                        TAX_BASE =line.totalNetAmount,
                        TAX_AMOUNT =0.0,
                        TAX_TYPE = line.vatRate,
                        TAX_RATE =0.0,
                        TAX_CATEGORY =line.totalNetAmount
                    }
                }

            };
            return new Inhouse
            {
                HEADER = header,
                liens = lines,
                Footer = footer

            };


        }




    }


}

