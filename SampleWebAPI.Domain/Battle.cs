using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Domain
{
    public class Battle
    {
        public int BattleId { get; set; }
        public string Name { get; set; }
        //relasi many to many
        public List<Samurai> Samurais { get; set; } = new List<Samurai>();
    }
}
