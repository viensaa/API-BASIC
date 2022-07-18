using AutoMapper;
using SampleWebAPI.Domain;
using SimpleWebAPI.DTO;

namespace SimpleWebAPI.Profiles
{
    public class ElementProfile : Profile
    {
        public ElementProfile()
        {
            CreateMap<Element, ElementDTO>();
            CreateMap<ElementDTO, Element>();
            CreateMap<ElementCreateDTO, Element>();
        }
    }
}
