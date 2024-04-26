namespace PocEconomicsAPI.Models.DTO.InhouseData
{
    public class Header
    {
        public string HEAD1 { get; set; }

        public string AGREEMENTNO { get; set; }

        public bool SEND_DOC_EDI = true;

        public bool SEND_DOC_PDF = false; 

        public string FORMAT { get; set; }

        public string DOCUMENTTYPE { get; set; }

        public string DOCUMENTNO { get; set; }

        public string DIRECTION { get; set; }

        public string DOCUMENT_UUID { get; set; }

        public string PROFILE { get; set; }

        public string INTERCHANGE_ID { get; set; }

        public string MESSAGE_ID { get; set; }

        public string INTERCHANGE_SENDER { get; set; }

        public string INTERCHANGE_RECEIVER { get; set; }

        public bool TEST_DOCUMENT = false;

        public HeadDate HEADDATE { get; set; }

        public Head2 HEAD2 { get; set; }

        public HeadBank HEADBANK { get; set; }

        public HeadContact HEADCONTACT { get; set; }

        public List<HeadCustom> HEADCUSTOM { get; set; }

        public List<HeadParty> HEADPARTY { get; set; }


    }
}
