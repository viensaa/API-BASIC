using SampleWebAPI.Domain;

namespace SimpleWebAPI.DTO
{
    public class SwordWithElementDTO
    {
        public int Id { get; set; }
        public string SwordName { get; set; }
        public List<ElementDTO> Element { get; set; }
    }
}
