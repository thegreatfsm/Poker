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
            Logic(game);
        }
        public void Logic(Game game)
        {
            decimal betSize;
            if(game.Turn == 0)
            {
                if (game.TotalMaxBet < 2 * game.BigBlind)
                {
                    CompCheck(game);
                }
                else
                {
                    CompFold();
                }
            }
            else
            {
                betSize = BetSize(game, FindBestHand(game));
                if (betSize > 0 && betSize > CurrentBet)
                {
                    if(betSize + CurrentBet < game.TotalMaxBet + 2 * game.BigBlind)
                    {
                        CompCheck(game);
                    }
                    else
                    {
                        CompBet(game, betSize);
                    }
                }
                else if (game.TotalMaxBet - CurrentBet < 2 * game.BigBlind)
                {
                    CompCheck(game);
                }
                else
                {
                    CompFold();
                }
            }
            
        }
        public int FindBestHand(Game game) // returns the CURRENT max hand value for a comp player, overloaded method
        {
            Dictionary<Hand, int> handValues = new Dictionary<Hand, int>();
            Card[] tempCards = new Card[2 + game.CommunityCards.Count()];
            Hand.Cards.CopyTo(tempCards);
            game.CommunityCards.CopyTo(tempCards, 2);

            foreach (var cards in GetCombinations<Card>(tempCards, 5)) // Creates a dictionary of all hands and hand values
            {
                handValues.Add(new Hand(cards.ToArray()), new Hand(cards.ToArray()).Evaluate());
            }

            return handValues.Values.Max();
        }
        public void CompCheck(Game game)
        {
            decimal checkSize = game.TotalMaxBet - TotalBet;
            decimal betSize = checkSize > Bank ? Bank : checkSize; // Checks if going all in
            game.ActivePot.Size += betSize;
            TotalBet += betSize;
            CurrentBet += betSize;
            Bank -= betSize;     
        }
        private decimal BetSize(Game game, int handValue) // currently does not work
        {
            decimal bettingRatio = (decimal)handValue / 3000000;
            decimal betSize = 0;
            if(bettingRatio < (decimal).2067)
            {
                betSize = 0;
            }
            else
            {
                betSize = Math.Round(Bank * bettingRatio/2);
            }
            return betSize;
        }
        private void CompBet(Game game, decimal betSize)
        {
            betSize = betSize >= Bank ? Bank : betSize; // all in
            TotalBet += betSize;
            CurrentBet += betSize;
            game.TotalMaxBet = TotalBet;
            game.ActivePot.Size += betSize;
            Bank -= betSize;
        }
        private void CompFold()
        {
            Fold = true;
            Active = false;
        }
    }
}
