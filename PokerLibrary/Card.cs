using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    
    public class Card
    {
        private static string[] Suits = { "Club", "Spade", "Heart", "Diamond" };
        private static string[] Faces = { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
        public string Suit { get; set; }
        public string Face { get; set; }
        public int Value { get; set; }
        public bool Active { get; set; }

        public Card(int suitNumber, int faceNumber)
        {
            Active = true;
            Face = Faces[faceNumber];
            Value = faceNumber + 1;
            Suit = Suits[suitNumber];
        }
    }
}
