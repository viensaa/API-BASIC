using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Domain
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        //relasi 1 to many
        public Samurai Samurai { get; set; }
        public int SamuraiId { get; set; }
    }
}
