using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Data.DAL;
using SampleWebAPI.Domain;
using SampleWebAPI.Helpers;
using SimpleWebAPI.DTO;

namespace SimpleWebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ElementController : ControllerBase
    {
        private readonly IElement _elementDAL;
        private readonly IMapper _mapper;

        public ElementController(IElement ElementDAL,IMapper mapper)
        {
            _elementDAL = ElementDAL;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<ElementDTO>> Get()
        {
            var results = await _elementDAL.GetAll();

            var data = _mapper.Map<IEnumerable<ElementDTO>>(results);
            return data;
        }

        [HttpGet("GetByName/{name}")]
        public async Task<IEnumerable<ElementDTO>> Get(string name)
        {
            var results = await _elementDAL.GetByName(name);
            var data = _mapper.Map<IEnumerable<ElementDTO>>(results);
            return data;
        }
        [HttpGet("GetById/{id}")]
        public async Task<ElementDTO>Get(int id)
        {
            var result = await _elementDAL.GetById(id);
            var data = _mapper.Map<ElementDTO>(result);
            return data;

        }

        [HttpPost("insert")]
        public async Task<ActionResult>Post(ElementCreateDTO elementCreateDTO)
        {
            try
            {
                var newElement = _mapper.Map<Element>(elementCreateDTO);
                var result = await _elementDAL.Insert(newElement);
                var Read = _mapper.Map<ElementDTO>(result);
                return CreatedAtAction("Get", new { id = result.Id }, Read);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult>Delete(int id)
        {
            try
            {
                await _elementDAL.DeleteById(id);
                return Ok("Data Berhasil di Hapus");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPut("Update")]

        public async Task<ActionResult>Put(ElementDTO elementDTO)
        {
            try
            {
                var UpdateSword = _mapper.Map<Element>(elementDTO);
                var result = await _elementDAL.Update(UpdateSword);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //elementwithsword
        [HttpPost("addElementToExistingSword")]
        public async Task<ActionResult> Post(int idElement, int idSword)
        {
            //var insertData = _mapper.Map<Element>(swordtoelement);
            await _elementDAL.addElementToSword(idElement,idSword);
            return Ok("Data Berhasil di Tambahkan");

        }
    }
}
