using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    public class Pot
    {
        public List<Player> CompetingPlayers { get; set; }
        public decimal Size { get; set; }

        public Pot(List<Player> aCompetingPlayers, decimal aSize)
        {
            CompetingPlayers = new List<Player>(aCompetingPlayers);
            Size = aSize;
        }
    }
}
