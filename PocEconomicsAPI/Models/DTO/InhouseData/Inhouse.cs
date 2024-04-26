namespace PocEconomicsAPI.Models.DTO.InhouseData
{
    public class Inhouse
    {
        public Header HEADER { get; set; }

        public List<Line> liens { get; set; }
        public Footer Footer { get; set; }


    }
}
