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
        //private List<Student> students;
        private readonly ISamurai _samuraiDAL;
        
        public SamuraisController(ISamurai samuraiDAL)
        {
            _samuraiDAL = samuraiDAL;
        }

        //DAY 4
        [HttpGet]
      public async Task<IEnumerable<SamuraiReadDTO>> Get()
        {
            List<SamuraiReadDTO> samuraiDTO = new List<SamuraiReadDTO>();
            var results = await _samuraiDAL.GetAll();
            foreach(var result in results)
            {
                samuraiDTO.Add(new SamuraiReadDTO
                {
                    Id = result.id,
                    Name = result.Name
                });
            }
            return samuraiDTO;
        }

        [HttpGet("{id}")]
        public async Task<SamuraiReadDTO> Get(int id)
        {
            SamuraiReadDTO samuraiDTO = new SamuraiReadDTO();
            var result = await _samuraiDAL.GetById(id);
            if (result == null) throw new Exception("Data tidak di temukan");

            samuraiDTO.Id = result.id;
            samuraiDTO.Name = result.Name;
            return samuraiDTO;
        }
       

        //menginsert data
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
                    Id = result.id,
                    Name = result.Name
                };
                return CreatedAtAction("Get", new {id = result.id}, samuraiReadDto);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        //


    }
}
