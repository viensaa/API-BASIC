using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Data.DAL;
using SampleWebAPI.Domain;
using SimpleWebAPI.DTO;
using SimpleWebAPI.Models;

namespace SimpleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraisController : ControllerBase
    {
        //generate auto mapper dan samurai dal
        private readonly ISamurai _samuraiDAL;
        private readonly IMapper _mapper;

        public SamuraisController(ISamurai samuraiDAL,IMapper mapper )
        {
            _samuraiDAL = samuraiDAL;
            _mapper = mapper;
        }

        //DAY 4
        [HttpGet]
      public async Task<IEnumerable<SamuraiReadDTO>> Get()
        {                    
            var results = await _samuraiDAL.GetAll();
          
            //menggunakan mapper
            var samuraiDTO = _mapper.Map<IEnumerable<SamuraiReadDTO>>(results);

            //tanpa mapper
            // List<SamuraiReadDTO> samuraiDTO = new List<SamuraiReadDTO>();
            //foreach(var result in results)
            //{
            //    samuraiDTO.Add(new SamuraiReadDTO
            //    {
            //        id = result.id,
            //        Name = result.Name
            //    });
            //}
            return samuraiDTO;
        }

        [HttpGet("SamuraiWithQuote")]
       public async Task<IEnumerable<SamuraiQuoteDTO>> GetSamuraiQuote()
        {                        
            //menggunakan automapper
            var results = await _samuraiDAL.SamuraiWIthQuote();
            var samuraiquoteDTO = _mapper.Map<IEnumerable<SamuraiQuoteDTO>>(results);

            //manual
            //List<SamuraiQuoteDTO> samuraiquoteDTO = new List<SamuraiQuoteDTO>();
            //foreach (var result in results)
            //{
            //    List<QuoteDTO> quotesDTO = new List<QuoteDTO>();
            //    foreach (var quote in result.Quotes)
            //    {
            //        quotesDTO.Add(new QuoteDTO
            //        {
            //            text = quote.Text
            //        });
            //    }
            //    samuraiquoteDTO.Add(new SamuraiQuoteDTO
            //    {
            //        Name = result.Name,
            //        Quotes = quotesDTO
            //    });
                return samuraiquoteDTO;                    
        }

        //samruaiwith sword 
        //[HttpGet("SamuraiWithSword")]
        //public async Task<IEnumerable<SamuraiWithSwordDTO>> GetSamuraiWithSword()
        //{
        //    var results = await _samuraiDAL.SamuraiWithSword();
        //    var DataRead = _mapper.Map<IEnumerable<SamuraiWithSwordDTO>>(results);
        //    return DataRead;
       // }

        //getbyname(buat sendiri)
        [HttpGet("GetByName/{name}")]
        public async Task<IEnumerable<SamuraiReadDTO>>Get(string name)
        {
            List<SamuraiReadDTO> ReadData = new List<SamuraiReadDTO>();
            var results = await _samuraiDAL.GetByName(name);
            if (results == null)
            {
                throw new Exception("Data tidak di temukan");
            }
            else
            {
                foreach(var result in results)
                {
                    ReadData.Add(new SamuraiReadDTO
                    {
                        id = result.id,
                        Name = result.Name
                    });
                }
                return ReadData;
            }
          
        }

        //mengambil data (pake GET)
        [HttpGet("GetById/{id}")]
        public async Task<SamuraiReadDTO> Get(int id)
        {
            SamuraiReadDTO samuraiDTO = new SamuraiReadDTO();
            var result = await _samuraiDAL.GetById(id);
            if (result == null) throw new Exception("Data tidak di temukan");

            samuraiDTO.id = result.id;
            samuraiDTO.Name = result.Name;
            return samuraiDTO;
        }



        //menginsert data (pake post)

        [HttpPost]
        public async Task<ActionResult> Post(SamuraiCreateDTO samuraiCreateDTO)
        {
            try
            {
                var newSamurai = new Samurai
                {
                    Name = samuraiCreateDTO.Name
                };
                var result = await _samuraiDAL.Insert(newSamurai);
                var samuraiReadDto = new SamuraiReadDTO
                {
                    id = result.id,
                    Name = result.Name
                };
                return CreatedAtAction("Get", new {id = result.id}, samuraiReadDto);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        //update data (pake put)
        [HttpPut]
        public async Task<ActionResult>Put(SamuraiReadDTO samuraiDTO)
        {
            try
            {
                var UpdateSamurai = new Samurai
                {
                    id = samuraiDTO.id,
                    Name = samuraiDTO.Name
                };
                var result = await _samuraiDAL.Update(UpdateSamurai);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        //delete data
        [HttpDelete("{id}")]
        public async Task<ActionResult>Delete(int id)
        {
            try
            {
                await _samuraiDAL.DeleteById(id);
                return Ok("data berhasil di delete");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        //DAY5

    }
}
