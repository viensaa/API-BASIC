namespace SimpleWebAPI.DTO
{
    public class SamuraiWithSwordDTO
    {
        public int id { get; set; }
        public string Name { get; set; }
        public List<SwordDTO> Sword { get; set; }

        public List<ElementDTO> Element { get; set; }
    }
}
