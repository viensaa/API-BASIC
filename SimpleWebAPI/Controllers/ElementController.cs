using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Data.DAL;

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
    }
}
