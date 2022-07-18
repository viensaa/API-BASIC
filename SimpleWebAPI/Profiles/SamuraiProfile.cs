using AutoMapper;
using SampleWebAPI.Domain;
using SimpleWebAPI.DTO;

namespace SimpleWebAPI.Profiles
{
    public class SamuraiProfile : Profile
    {
        //mmebuat map <dari mana, ke mana> dengan fiel yang  sama
        //pada data ini file(kolom) samurai dan samuraiReadDTO itu harus sama
        public SamuraiProfile()
        {
            CreateMap<Samurai, SamuraiReadDTO>();
            CreateMap<SamuraiReadDTO, Samurai>();
            CreateMap<SamuraiCreateDTO, Samurai>();
            //CreateMap<Samurai, SwordDTO>();

            CreateMap<Samurai, SamuraiQuoteDTO>();
            CreateMap<Samurai, SamuraiWithSwordDTO>();

            

            CreateMap<QuoteDTO, Quote>();
            CreateMap<Quote, QuoteDTO>();
            


        }
        
    }
}
