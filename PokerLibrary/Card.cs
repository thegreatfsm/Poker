using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PokerLibrary
{
    
    public class Card : IComparable<Card>
    {
        private static string[] Suits = { "Club", "Spade", "Heart", "Diamond" };
        private static string[] Faces = { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
        public string Suit { get; set; }
        public string Face { get; set; }
        public int Value { get; set; }
        public int CompareValue { get; set; }
        public Image CardImage { get; set; }

        public Card(int suitNumber, int faceNumber, int aCompareValue)
        {
            
            Face = Faces[faceNumber];
            Value = faceNumber + 1;
            Suit = Suits[suitNumber];
            CompareValue = aCompareValue;
            CardImage = Image.FromFile($@"C:\Users\Joseph\source\repos\Poker\PokerLibrary\CardImages\{CompareValue}.png");
        }

        public int CompareTo(Card card)
        {
           if(CompareValue > card.CompareValue)
            {
                return 1;
            }
           else if(CompareValue == card.CompareValue)
            {
                return 0;
            }
            else
            {
                return -1;
            }
            
        }
    }
}
