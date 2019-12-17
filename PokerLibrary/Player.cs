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
        public bool Fold { get; set; }
        public Hand Hand { get; set; }
        public Hand OriginalHand { get; set; }
        public decimal TotalBet { get; set; }
        public decimal CurrentBet { get; set; }
        public decimal Bank { get; set; }
        public bool BigBlind { get; set; }
        public bool SmallBlind { get; set; }
        public bool Dealer { get; set; }
        public int PlayerNumber { get; set; }


        public Player(decimal aBank, int aPlayerNumber)
        {
            Active = true;
            Fold = false;
            PlayerNumber = aPlayerNumber;
            Bank = aBank;
            Hand = new Hand();
            OriginalHand = new Hand();
            BigBlind = false;
            SmallBlind = false;
            Dealer = false;
        }

        public void FindBestHand(List<Card> communityCards) // find the best possible hand for a player by testing all combinations
        {
            Dictionary<Hand, int> handValues = new Dictionary<Hand, int>();
            Card[] tempCards = new Card[7];
            Hand.Cards.Clear();
            Hand.Cards = new List<Card>(OriginalHand.Cards);
            communityCards.CopyTo(tempCards);
            Hand.Cards.CopyTo(tempCards, 5);

            foreach(var cards in GetCombinations<Card>(tempCards, 5)) // Creates a dictionary of all hands and hand values
            {
                handValues.Add(new Hand(cards.ToArray()), new Hand(cards.ToArray()).Evaluate());
            }

            var biggestHand = handValues.Values.Max();

            foreach(var key in handValues.Keys)
            {
                if(handValues[key] == biggestHand)
                {
                    Hand = key;
                }
            }
        }

        static public IEnumerable<IEnumerable<T>> GetCombinations<T>(IEnumerable<T> items, int k) where T:IComparable<T>// returns all possible combinations of k size from T[] items in a List
        {
            if (k == 1) return items.Select(t => new T[] { t });
            return GetCombinations(items, k - 1)
                .SelectMany(t => items.Where(o => o.CompareTo(t.Last()) > 0),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        public override string ToString() => $"Player Number: {PlayerNumber} Bankroll: {Bank:C} Current Bet:{TotalBet:C} Playing: {(Active ? "Yes": "No")} {(SmallBlind ? "Small Blind" : "")+(BigBlind ? "Big Blind" : "")+(Dealer ? "Dealer": "")}";
    }
}

