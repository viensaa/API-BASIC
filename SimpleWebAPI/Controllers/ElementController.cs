using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Data.DAL;
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
    }
}
