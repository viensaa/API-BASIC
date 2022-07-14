using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Data.DAL;
using SampleWebAPI.Domain;
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

        [HttpGet]
      public async Task<IEnumerable<Samurai>> Get()
        {
            var results = await _samuraiDAL.GetAll();
            return results;
        }
        [HttpGet("{id}")]
        public async Task<Samurai> Get(int id)
        {
            var result = await _samuraiDAL.GetById(id);
            if (result == null) throw new Exception("Data tidak di temukan");
            return result;
        }

    }
}
