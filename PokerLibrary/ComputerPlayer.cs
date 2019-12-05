using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    class ComputerPlayer : Player // Add computer decision making
    {
        public ComputerPlayer(decimal aBank) : base(aBank)
        {
            Bank = aBank;
            BigBlind = false;
            SmallBlind = false;
        }
    }
}
