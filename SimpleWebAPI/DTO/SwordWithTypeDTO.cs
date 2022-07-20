using Type = SampleWebAPI.Domain.Type;
namespace SimpleWebAPI.DTO
{
    public class SwordWithTypeDTO
    {
        public int Id { get; set; }
        public string SwordName { get; set; }
        public int SamuraiId { get; set; }
        public TypeDTO Type { get; set; }

    }
}
