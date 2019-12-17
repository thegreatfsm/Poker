using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    
    public class Hand //Composed of cards, will have an "Evaluate()" function return an integer for easy comparison of hands.
    {
        enum Hands {HighCard, Pair, TwoPair, ThreeOfAKind, Straight, Flush, FullHouse, FourOfAKind, StraightFlush, RoyalFlush  }
        public List<Card> Cards { get; set; }
        

        public Hand()
        {
            Cards = new List<Card>();
        }
        public Hand(Card[] cards)
        {
            Cards = cards.ToList();
        }

        public int Evaluate() // Calls on functions and gives each hand a number value
        {
            var hand = Hands.HighCard;
            string[] suits = new string[5];
            string[] faces = new string[5];
            int[] values = new int[5];
            int value = 0;
            int kicker = 0;
            int kicker2 = 0;
            int kicker3 = 0;
            for(int i = 0; i < 5; i++)
            {
                suits[i] = Cards[i].Suit;
                faces[i] = Cards[i].Face;
                values[i] = Cards[i].Value;
            }
            if (faces.Contains("King") && faces.Contains("Queen") && faces.Contains("Jack") && faces.Contains("Ace") && faces.Contains("Ten") && IsFlush(suits))
            {
                hand = Hands.RoyalFlush;
            }
            else if(IsFlush(suits) && IsStraight(values))
            {
                hand = Hands.StraightFlush;
            }
            else if (IsFourOfaKind(values, out value, out kicker))
            {
                hand = Hands.FourOfAKind;
            }
            else if (IsFullHouse(values, out value, out kicker))
            {
                hand = Hands.FullHouse;
            }
            else if (IsFlush(suits))
            {
                hand = Hands.Flush;
            }
            else if (IsStraight(values))
            {
                hand = Hands.Straight;
            }
            else if (IsThreeOfaKind(values, out value, out kicker, out kicker2))
            {
                hand = Hands.ThreeOfAKind;
            }
            else if (IsTwoPair(values, out value, out kicker, out kicker2))
            {
                hand = Hands.TwoPair;
            }
            else if (IsPair(values, out value, out kicker, out kicker2, out kicker3))
            {
                hand = Hands.Pair;
            }
            else
            {
                hand = Hands.HighCard;
            }
            Array.Sort(values);
            switch (hand)
            {
                case Hands.HighCard:
                    return values[4]*28561 + values[3]*2197 + values[2]*169 + values[1]*13 + values[0];
                case Hands.Pair:
                    return 1000000 + value*2197 + kicker * 169 + kicker2 * 13 + kicker3;
                case Hands.TwoPair:
                    return 1250000 + value*169 + kicker*13 + kicker2;
                case Hands.ThreeOfAKind:
                    return 1300000 + value*169 + kicker*13 + kicker2;
                case Hands.Straight:
                    if (values[4] == 13 && values[0] == 1)
                    {
                        return 1350000 + values[3];
                    }
                    else
                    {
                        return 1350000 + values[4];
                    }
                case Hands.Flush:
                    return 1400000 + values[4] * 28561 + values[3] * 2197 + values[2] * 169 + values[1] * 13 + values[0];
                case Hands.FullHouse:
                    return 2250000 + (value * 169 + 1) + kicker*13;
                case Hands.FourOfAKind:
                    return 2300000 +  kicker*13 + (value * 169 + 1);
                case Hands.StraightFlush:
                    if (values[4] == 13 && values[0] == 1)
                    {
                        return 2500000 + values[3];
                    }
                    else
                    {
                        return 2500000 + values[4];
                    }
                case Hands.RoyalFlush:
                    return 3000000;
                default:
                    return 0;

            }

        }
        private bool IsFlush(string[] suits)
        {
            var comparisonSuit = suits[0];
            foreach (var suit in suits)
            {
                if (suit != comparisonSuit)
                {
                    return false;
                }
            }
            return true;
        }
        private bool IsStraight(int[] values)
        {
            int[] tempvalues = new int[5];
            values.CopyTo(tempvalues,0);
            Array.Sort(tempvalues);

            for (int i = 0; i < tempvalues.Length - 1 ; i++)
            {
                if (i == 3 && tempvalues[i - 3] == 1 && tempvalues[i + 1] == 13) // Checks for special case
                {
                    return true;
                }

                if (tempvalues[i] + 1 == tempvalues[i + 1])
                {
                    
                 
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        private bool IsFourOfaKind(int[] values, out int value, out int kicker)
        {
            int[] tempvalues = new int[5];
            values.CopyTo(tempvalues, 0);
            Array.Sort(tempvalues);
            if (tempvalues[0] == tempvalues[1]) // Case where the first four match
            {
                for (int i = 1; i < 3; i++)
                {
                    if (tempvalues[i] != tempvalues[i + 1])
                    {
                        value = 0;
                        kicker = 0;
                        return false;
                    }   
                }
                value = tempvalues[0];
                kicker = tempvalues[4];
                return true;
            }
            else if(tempvalues[3] == tempvalues[4]) // Case where the back four match
            {
                for (int i = 3; i > 1; i--)
                {
                    if (tempvalues[i] != tempvalues[i - 1])
                    {
                        value = 0;
                        kicker = 0;
                        return false;
                    }
                }
                value = tempvalues[4];
                kicker = tempvalues[0];
                return true;
            }
            else
            {
                value = 0;
                kicker = 0;
                return false;
            }
            
        }
        private bool IsFullHouse(int[] values, out int value, out int kicker)
        {
            int[] tempvalues = new int[5];
            values.CopyTo(tempvalues, 0);
            Array.Sort(tempvalues);
            if (tempvalues[0] == tempvalues[2] && tempvalues[2] == tempvalues[1] && tempvalues[3] == tempvalues[4]) // Three pair front half
            {
                value = tempvalues[0];
                kicker = tempvalues[3];
                return true;
            }
            else if (tempvalues[0] == tempvalues[1] && tempvalues[4] == tempvalues[3] && tempvalues[3] == tempvalues[2]) // Three pair back half
            {
                value = tempvalues[4];
                kicker = tempvalues[0];
                return true;
            }
            else
            {
                value = 0;
                kicker = 0;
                return false;
            }
        }
        private bool IsThreeOfaKind(int[] values, out int value, out int kicker, out int kicker2)
        {
            int[] tempvalues = new int[5];
            values.CopyTo(tempvalues, 0);
            Array.Sort(tempvalues);
            if (tempvalues[0] == tempvalues[1] && tempvalues[1] == tempvalues[2]) // Case where the first three match
            {
                value = tempvalues[0];
                kicker = tempvalues[4];
                kicker2 = tempvalues[3];
                return true;
            }
            else if(tempvalues[1] == tempvalues[2] && tempvalues[2] == tempvalues[3]) // Case where middle three match
            {
                value = tempvalues[1];
                kicker = tempvalues[4];
                kicker2 = tempvalues[0];
                return true;
            }
            else if (tempvalues[2] == tempvalues[3] && tempvalues[3] == tempvalues[4]) // Case where the back three match
            {
                value = tempvalues[2];
                kicker = tempvalues[1];
                kicker2 = tempvalues[0];
                return true;
            }
            else
            {
                value = 0;
                kicker = 0;
                kicker2 = 0;
                return false;
            }
        }
        private bool IsTwoPair(int[] values, out int value, out int kicker, out int kicker2) // need to add kicker support
        {
            int[] tempvalues = new int[5];
            values.CopyTo(tempvalues, 0);
            Array.Sort(tempvalues);
            if(tempvalues[0] == tempvalues[1] && tempvalues[2] == tempvalues[3]) //1 2 3 4 are pairs
            {
                value = tempvalues[3];
                kicker = tempvalues[0];
                kicker2 = tempvalues[4];
                return true;
            }
            else if(tempvalues[1] == tempvalues[2] && tempvalues[3] == tempvalues[4]) // 2 3 4 5 are pairs
            {
                value = tempvalues[4];
                kicker = tempvalues[1];
                kicker2 = tempvalues[0];
                return true;
            }
            else if (tempvalues[0] == tempvalues[1] && tempvalues[3] == tempvalues[4]) // 1 2 4 5 are pairs
            {
                value = tempvalues[4];
                kicker = tempvalues[0];
                kicker2 = tempvalues[2];
                return true;
            }
            else
            {
                value = 0;
                kicker = 0;
                kicker2 = 0;
                return false;
            }
        }
        private bool IsPair(int[] values, out int value, out int kicker, out int kicker2, out int kicker3)
        {
            int[] tempvalues = new int[5];
            values.CopyTo(tempvalues, 0);
            Array.Sort(tempvalues);
            value = 0;
            kicker = 0;
            kicker2 = 0;
            kicker3 = 0;
            if(tempvalues[0] == tempvalues[1] || tempvalues[1] == tempvalues[2] || tempvalues[2] == tempvalues[3] || tempvalues[3] == tempvalues[4]) // Checks for pairs
            {
                for(int i=0; i<values.Length-1; i++)
                {
                    if (tempvalues[i] == tempvalues[i + 1]) // Get the number for the pair
                    {
                        value = tempvalues[i];
                        switch (i)
                        {
                            case 0:
                                kicker = tempvalues[4];
                                kicker2 = tempvalues[3];
                                kicker3 = tempvalues[2];
                                break;
                            case 1:
                                kicker = tempvalues[4];
                                kicker2 = tempvalues[3];
                                kicker3 = tempvalues[0];
                                break;
                            case 2:
                                kicker = tempvalues[4];
                                kicker2 = tempvalues[1];
                                kicker3 = tempvalues[0];
                                break;
                            case 3:
                                kicker = tempvalues[2];
                                kicker2 = tempvalues[1];
                                kicker3 = tempvalues[0];
                                break;
                        }
                        break;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
