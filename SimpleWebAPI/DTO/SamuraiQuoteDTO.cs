using SampleWebAPI.Domain;

namespace SimpleWebAPI.DTO
{
    public class SamuraiQuoteDTO
    {
        public int id { get; set; }
        public string Name { get; set; }
        public List<QuoteDTO> Quotes { get; set; }
       
    }
}
