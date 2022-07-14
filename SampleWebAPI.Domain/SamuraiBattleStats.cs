using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Domain
{
    public class SamuraiBattleStats
    {
        public string Name { get; set; }
        public int? NumberOfBattles { get; set; }
        public string EarliestBattle { get; set; }
    }
}
