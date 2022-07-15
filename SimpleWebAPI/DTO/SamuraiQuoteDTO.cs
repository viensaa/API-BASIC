using SampleWebAPI.Domain;

namespace SimpleWebAPI.DTO
{
    public class SamuraiQuoteDTO
    {
        public string Name { get; set; }
        public List<QuoteDTO> Quotes { get; set; }
       
    }
}
