using AutoMapper;
using SampleWebAPI.Domain;
using SimpleWebAPI.DTO;
using Type = SampleWebAPI.Domain.Type;

namespace SimpleWebAPI.Profiles
{
    public class SwordProfile : Profile
    {
        public SwordProfile()
        {
            CreateMap<Sword, SwordDTO>();
            CreateMap<SwordDTO, Sword>();
            CreateMap<SwordCreateDTO, Sword>();
            //CreateMap<SwordWithTypeDTO, Sword>();
            CreateMap<Sword, SwordSamuraiElementDTO>();
            CreateMap<Sword, SwordWithTypeDTO>();


            CreateMap<SwordWithTypeDTO, Sword>();
            CreateMap<SwordWithTypeDTO, Type>();
            CreateMap<SwordWithTypeDTO, TypeCreateDTO>();
            CreateMap<SwordWithTypeDTO, SwordCreateDTO>();
            CreateMap<SwordWithTypeDTO, TypeDTO>();


            CreateMap<TypeCreateDTO, SwordWithTypeDTO>();
            CreateMap<AddSwordToExistingElementDTO, Sword>();
            CreateMap<AddSwordToExistingElementDTO, Element>();


        }
        
    }
}
