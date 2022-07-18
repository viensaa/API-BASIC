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
    }
}
