using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Data.DAL;
using SampleWebAPI.Domain;
using SimpleWebAPI.DTO;

namespace SimpleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwordController : ControllerBase
    {
        private readonly ISword _swordDAL;
        private readonly IMapper _mapper;

        public SwordController(ISword SwordDAL,IMapper mapper)
        {
            _swordDAL = SwordDAL;
            _mapper = mapper;
        }

        //memanggil semua data
        [HttpGet]
        public async Task<IEnumerable<SwordDTO>> Get()
        {
            var results = await _swordDAL.GetAll();

            var data = _mapper.Map<IEnumerable<SwordDTO>>(results);
            return data;
        }

        //insert
        [HttpPost]
        public async Task<ActionResult> Post(SwordCreateDTO swordcreatedto)
        {
            try
            {
                //tanpa mapper
                //var newSword = new Sword
                //{
                //    SwordName = swordcreatedto.SwordName,
                //};
                //var result = await _swordDAL.Insert(newSword);
                //var ReadDto = new SwordDTO
                //{
                //    Id = result.Id,
                //    SwordName = result.SwordName
                //};
                //return CreatedAtAction("Get", new { id = result.Id }, ReadDto);
                //menggunakan mapper
                var NewSword = _mapper.Map<Sword>(swordcreatedto);
                var result = await _swordDAL.Insert(NewSword);
                var Read = _mapper.Map<SwordDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id }, Read);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
