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

        //GetdatabyName
        [HttpGet("GetByName/{name}")]
        public async Task<IEnumerable<SwordDTO>>Get(string name)
        {
            var results = await _swordDAL.GetByName(name);

            var data = _mapper.Map<IEnumerable<SwordDTO>>(results);
            return data;
        }

        //GetByid
        [HttpGet("GetById/{id}")]
        public async Task<SwordDTO>Get(int id)
        {
            var result = await _swordDAL.GetById(id);
            //if (result == null) throw new Exception("Data tidak di temukan");

            var data = _mapper.Map<SwordDTO>(result);
            return data;
        }

        //insert
        [HttpPost("insert")]
        public async Task<ActionResult> Post(SwordCreateDTO swordcreatedto)
        {
            try
            {                
                var NewSword = _mapper.Map<Sword>(swordcreatedto);
                var result = await _swordDAL.Insert(NewSword);
                return Ok("Data bershasil di tambahkan");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult>Delete(int id)
        {
            try
            {
                await _swordDAL.DeleteById(id);
                return Ok("data berhasil di hapus");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //Update
        [HttpPut("Update")]
        public async Task<ActionResult>Put(SwordDTO swordDTO)
        {
            try
            {
                var UpdateSword = _mapper.Map<Sword>(swordDTO);
                var result = await _swordDAL.Update(UpdateSword);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        
        

    }
}
