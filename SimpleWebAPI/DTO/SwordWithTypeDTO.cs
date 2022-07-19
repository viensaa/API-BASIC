using Type = SampleWebAPI.Domain.Type;
namespace SimpleWebAPI.DTO
{
    public class SwordWithTypeDTO
    {        
        public TypeCreateDTO TypeSword { get; set; }
        public SwordCreateDTO SwordName { get; set; }

    }
}
