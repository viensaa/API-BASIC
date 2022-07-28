using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Data.DAL;
using SampleWebAPI.Helpers;
using SimpleWebAPI.DTO;
using Type = SampleWebAPI.Domain.Type;

namespace SimpleWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly Itype _typeDAL;
        private readonly IMapper _mapper;

        public TypeController(Itype TypeDAL, IMapper mapper)
        {
            _typeDAL = TypeDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TypeDTO>> Get()
        {
            var results = await _typeDAL.GetAll();

            var data = _mapper.Map<IEnumerable<TypeDTO>>(results);
            return data;
        }

        [HttpPost("insert")]
        public async Task<ActionResult> Post(TypeCreateDTO typeCreateDTO)
        {
            try
            {
                var newType = _mapper.Map<Type>(typeCreateDTO);
                var result = await _typeDAL.Insert(newType);
                var Read = _mapper.Map<TypeDTO>(result);
                return CreatedAtAction("Get", new { id = result.Id }, Read);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        //menambahkan sword dan type sekaligus
        [HttpPost("SwordAndType")]
        public async Task<ActionResult> Post(SwordWithTypeDTO swordWithTypeDTO)
        {
            var newData = _mapper.Map<Type>(swordWithTypeDTO);
            var result = await _typeDAL.AddSwordWithType(newData);
            var Read = _mapper.Map<TypeDTO>(result);
            return CreatedAtAction("Get", new { id = result.Id }, Read);
        }
    }
}
