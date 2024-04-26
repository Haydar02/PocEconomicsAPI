namespace PocEconomicsAPI.Models.DTO.InhouseData
{
    public class Footer
    {
            public Foot1 FOOT1 { get; set; }

            public List<FootTaxList> FOOTTAXLIST { get; set; }
        public Footer footer { get; set; }

        }



        public class Foot1

        {

            public string NO_OF_LINES { get; set; }

            public string NO_OF_QTY { get; set; }

            public string TOTAL_AMOUNT { get; set; }

            public string TOTAL_LINE_AMOUNT { get; set; }

            public string ROUNDOFF { get; set; }

            public string TOTAL_DISC_AMOUNT { get; set; }

            public string TOTAL_FEE { get; set; }

            public string TOTAL_TAXBASE_AMOUNT { get; set; }

            public string TOTAL_TAX_AMOUNT { get; set; }

        }



        public class FootTaxList

        {

            public string TAX_BASE { get; set; }

            public string TAX_AMOUNT { get; set; }

            public string TAX_TYPE { get; set; }

            public string TAX_RATE { get; set; }

            public string TAX_CATEGORY { get; set; }
        }
}
