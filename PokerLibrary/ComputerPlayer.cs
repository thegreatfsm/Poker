using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    public class ComputerPlayer : Player // Add computer decision making
    {
        public ComputerPlayer(decimal aBank, int aPlayerNumber) : base(aBank, aPlayerNumber)
        {
            Bank = aBank;
            BigBlind = false;
            SmallBlind = false;
        }

        // ----- here's the SAUCE baby

        public void BettingAI(Game game) // ai is dependent on value of hands or value of cards or of a potential hand
        {
            Dictionary<Hand, int> handValues = new Dictionary<Hand, int>();
            Card[] possibleCards = new Card[game.CommunityCards.Count() + Hand.Cards.Count()];


            if (possibleCards.Length >= 5)
            {
                foreach(var cards in GetCombinations(possibleCards, 5))
                {
                    var hand = new Hand(cards.ToArray());
                    handValues.Add(hand, hand.Evaluate());
                }

            }
        }

        public void Check(Game game)
        {
            decimal checkSize = game.TotalMaxBet - TotalBet;
            decimal betSize = checkSize > Bank ? Bank : checkSize; // Checks if going all in
            game.ActivePot.Size += betSize;
            TotalBet += betSize;
            CurrentBet += betSize;
            Bank -= betSize;
            
        }
    }
}
