using AutoMapper;
using SampleWebAPI.Domain;
using SimpleWebAPI.DTO;

namespace SimpleWebAPI.Profiles
{
    public class SwordProfile : Profile
    {
        public SwordProfile()
        {
            CreateMap<Sword, SwordDTO>();
            CreateMap<SwordDTO, Sword>();
            CreateMap<SwordCreateDTO, Sword>();
            CreateMap<Sword, SwordSamuraiElementDTO>();

        }
        
    }
}
