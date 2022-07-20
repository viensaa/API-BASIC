using AutoMapper;
using SampleWebAPI.Domain;
using SimpleWebAPI.DTO;
using Type = SampleWebAPI.Domain.Type;

namespace SimpleWebAPI.Profiles
{
    public class TypeProfile : Profile
    {
        public TypeProfile()
        {
            CreateMap<Type, TypeDTO>();
            CreateMap<TypeDTO, Type>();
            CreateMap<TypeCreateDTO, Type>();
            CreateMap<SwordWithTypeDTO, TypeCreateDTO>();
            CreateMap<SwordWithTypeDTO, SwordCreateDTO>();

           
        }
    }
}
