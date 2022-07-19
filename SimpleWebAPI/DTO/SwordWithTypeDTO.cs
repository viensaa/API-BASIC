using Type = SampleWebAPI.Domain.Type;
namespace SimpleWebAPI.DTO
{
    public class SwordWithTypeDTO
    {
        public int SamuraiId { get; set; }
        public string SwordName { get; set; }
        public TypeDTO TypeSword { get; set; }

    }
}
