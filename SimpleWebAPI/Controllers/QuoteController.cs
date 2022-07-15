using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Data.DAL;
using SimpleWebAPI.DTO;
using SampleWebAPI.Domain;

namespace SimpleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuote _QuoteDAL;

        public QuoteController(IQuote quoteDAL)
        {
            _QuoteDAL = quoteDAL;
        }
        
        //day 5
        [HttpGet]
        public async Task<IEnumerable<QuoteDTO>> Get()
        {
            List<QuoteDTO> quotesDTO = new List<QuoteDTO>();
            var results = await _QuoteDAL.GetAll();
            foreach (var result in results)
            {
                quotesDTO.Add(new QuoteDTO
                {
                    id = result.Id,
                    text = result.Text
                    
                });
            }
            return quotesDTO;
        }
    }
}
