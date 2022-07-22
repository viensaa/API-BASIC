using AutoMapper;
using SampleWebAPI.Domain;
using SimpleWebAPI.DTO;

namespace SimpleWebAPI.Profiles
{
    public class UserProfile : Profile
    {
        public  UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<RegisterDTO, User>();
            
        }
    }
}
