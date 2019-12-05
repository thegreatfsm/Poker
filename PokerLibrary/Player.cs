using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    public class Player //Add the bet function to game, game class will award player with best hand // need to evaulate best possible hand
    {
        public bool Active { get; set; }
        public Hand Hand { get; set; }
        public decimal CurrentBet { get; set; }
        public decimal Bank { get; set; }
        public bool BigBlind { get; set; }
        public bool SmallBlind { get; set; }


        public Player(decimal aBank)
        {
            Active = true;
            Bank = aBank;
            Hand = new Hand();
            BigBlind = false;
            SmallBlind = false;
        }

        public void FindBestHand(List<Card> communityCards) // do this
        {
            Dictionary<Hand, int> handValues = new Dictionary<Hand, int>();
            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                   // case 0:
                    //    handValues.Add(new Hand())
                }
                    
            }
        }
    }
}
