using SampleWebAPI.Domain;

namespace SimpleWebAPI.DTO
{
    public class SwordSamuraiElementDTO
    {
        //public int Id { get; set; }
        public SamuraiReadDTO Samurai { get; set; }
        public string SwordName { get; set; }
        public List<ElementDTO> Element { get; set; }
        //  public Samurai Samurai { get; set; }
        //public int Weight { get; set; }
        //  public List<Element> Element { get; set; }
          public TypeDTO Type { get; set; }




    }
}
