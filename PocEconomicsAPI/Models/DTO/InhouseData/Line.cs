namespace PocEconomicsAPI.Models.DTO.InhouseData
{
    public class Line

    {

        public string DOCUMENTTYPE { get; set; }

        public string DOCUMENTNO { get; set; }

        public string LINE_ID { get; set; }
        public LineItem LINEITEM { get; set; }
        public LineAmount LINEAMOUNT { get; set; }
        public LineQty LINEQTY { get; set; }
        public LineRef LINEREF { get; set; }
        public List<LineCustom> LINECUSTOM { get; set; }

    }



    public class LineItem

    {

        public string ITEM_NO_STANDARD { get; set; }

        public string ITEM_MANUFACT_ITEM_NO { get; set; }

        public string ITEM_VENDOR_ITEM_NO { get; set; }

        public string ITEM_SELLERS_ITEM_NO { get; set; }

        public string DATE_EXPECT_RECEIPT { get; set; }

        public string BACKORDER { get; set; }

        public string DESCRIPTION { get; set; }

        public string LINE_STATUS { get; set; }

        public string DESCRIPTION2 { get; set; }

    }



    public class LineAmount

    {

        public string UNIT_PRICE_SALE { get; set; }

        public string UNIT_PRICE_COST { get; set; }

        public string VAT_AMOUNT { get; set; }

        public string AMOUNT_EX_VAT { get; set; }

        public string AMOUNT_INCL_VAT { get; set; }

        public string VAT_PCT { get; set; }

        public string DISCOUNT_AMOUNT { get; set; }

    }



    public class LineQty

    {

        public string UNIT_OF_MEAS { get; set; }

        public string QTY_DOCUMENT { get; set; }

        public string QTY_BACKORDER { get; set; }

        public string QTY_PER_UNIT_MEAS { get; set; }

        public string QTY_TOTAL_SHIPPED { get; set; }

        public string QTY_ORIG_ORDER { get; set; }

        public string VARIANT { get; set; }

    }



    public class LineRef

    {

        public string DOC_REF_NO { get; set; }

        public string DOC_REF_LINE_NO { get; set; }

        public string PACK_REF_NO { get; set; }

        public string INVOICE_REF { get; set; }

        public string INVOICE_REF_LINE_NO { get; set; }

    }



    public class LineCustom

    {

        public string FIELDCODE { get; set; }

        public string FIELDTYPE { get; set; }

        public string VALUE { get; set; }

    }
}
