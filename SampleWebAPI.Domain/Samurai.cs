using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Domain
{
    public class Samurai
    {
        public int id { get; set; }
        public string  Name { get; set; }

        //membaut relasi tabel in berelasi many to many
        public List<Quote> Quotes { get; set; } = new List<Quote>();
        public List<Battle> Battles { get; set; } = new List<Battle>();

        public List<Sword> Swords { get; set; } = new List<Sword>();

        //relasi 1 to 1
        public Horse Horse { get; set; }
    }
}
