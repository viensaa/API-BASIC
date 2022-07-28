using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Data.DAL;
using SampleWebAPI.Domain;
using SampleWebAPI.Helpers;
using SimpleWebAPI.DTO;

namespace SimpleWebAPI.Controllers
{
    [Authorize]
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
        public async Task<ActionResult> Post(SwordCreateDTO swordCreateDTO)
        {
            try
            {
                var newSword = _mapper.Map<Sword>(swordCreateDTO);
                var result = await _swordDAL.Insert(newSword);
                var Read = _mapper.Map<SwordDTO>(result);
                return CreatedAtAction("Get", new { id = result.Id }, Read);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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

        [HttpDelete("DeleteElementOnSword/{id}")]
        public async Task<ActionResult>DeleteElement(int id)
        {
            try
            {
                await _swordDAL.DeleteElementOnSword(id);
                return Ok("Data Berhasil di Hapus");
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

        //mengambil data samurai dan sword
        [HttpGet("samruaisowrdwithelement")]
        public async Task<IEnumerable<SwordSamuraiElementDTO>> GetSamuraiSwordWithElement()
        {
            var results = await _swordDAL.SamuraiSwordWithElement();
            var DataRead = _mapper.Map<IEnumerable<SwordSamuraiElementDTO>>(results);
            return DataRead;

        }

        [HttpGet("SwordWithType(Pagging)")]
        public async Task<IEnumerable<SwordWithTypeDTO>> GetSwordiWithType(int page)
        {
            var results = await _swordDAL.GetSwordWithType(page);
            var dataRead = _mapper.Map<IEnumerable<SwordWithTypeDTO>>(results);
            return dataRead;
        }

        [HttpGet("SwordWithElement")]
        public async Task<IEnumerable<SwordWithElementDTO>> GetSwordWithElement()
        {
            var results = await _swordDAL.SwordWithElement();
            var dataRead = _mapper.Map<IEnumerable<SwordWithElementDTO>>(results);
            return dataRead;
        }


        //menambahakn Sword beserta dengan Type (ajib bener)
        [HttpPost("addSwordWithType")]
        public async Task<ActionResult> Post(SwordWithTypeDTO swordWithTypeDTO)
        {
            var newData = _mapper.Map<Sword>(swordWithTypeDTO);
            var result = await _swordDAL.Insert(newData);
            var Read = _mapper.Map<SwordSamuraiElementDTO>(result);
            return CreatedAtAction("Get", new { id = result.Id }, Read);
        }



        [HttpPost("addSwordToExistingElement")]
        public async Task<ActionResult>Post(AddSwordToExistingElementDTO swordtoelement)
        {
            var insertData = _mapper.Map<Sword>(swordtoelement);
            var result = await _swordDAL.AddExistingSwordToElement(insertData);
            return Ok("Berhasil Menambahkan ");
        }



    }
}
