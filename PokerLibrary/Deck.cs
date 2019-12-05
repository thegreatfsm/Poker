using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    public class Deck
    {
        public List<Card> CardList { get; set; }

        public Deck()
        {
            CardList = new List<Card>();
            for(int i=0; i<52; i++)
            {
                CardList.Add(new Card(i/13, i%13));
            }
        }
        public void Shuffle()
        {
            var num = new Random();
            for (int i = 0; i < CardList.Count(); i++)
            {
                var replace = num.Next(0, 52);
                var temp = CardList[i];
                CardList[i] = CardList[replace];
                CardList[replace] = temp;
            }
        }
    }
}
