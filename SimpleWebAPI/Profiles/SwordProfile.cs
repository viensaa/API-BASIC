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
            CreateMap<SwordWithTypeDTO, Sword>();
            CreateMap<SwordWithTypeDTO, Type>();
            CreateMap<Type, SwordWithTypeDTO>();


        }
        
    }
}
