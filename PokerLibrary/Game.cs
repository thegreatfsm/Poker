using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    public class Game // Game consists of Deck and Community Cards, as well as has access to each player. Method for giving money to player for winning hand.
    {
        // Implement side pot and blinds(done), then work on UI game logic almost done, work on checking if each player has bet, requires computer ai.
        private int numberOfPlayers;
        public int Turn { get; set; }
        public List<Pot> Pots { get; set; }
        
        public decimal Bet { get; set; }
        private Deck Deck { get; set; }
        private List<Player> players;
        public List<Card> CommunityCards { get; set; }

        public Game (int aNumberOfPlayers, decimal PlayerBank)
        {
            numberOfPlayers = aNumberOfPlayers;
            Turn = 1;
            
            Bet = 0;
            Deck = new Deck();
            Deck.Shuffle();
            for (int i = 0; i <= numberOfPlayers; i++)
            {
                if (i == 0)
                {
                    players.Add(new Player(PlayerBank));
                    
                }
                else
                {
                    players.Add(new ComputerPlayer(PlayerBank));
                }
            }
            players[0].BigBlind = true;
            players[1].SmallBlind = true;
            Pots = new List<Pot>();
            Pots.Add(new Pot(players, 0));
            CommunityCards = new List<Card>();
            CommunityCardsDraw();
            foreach(var player in players)
            {
                PlayerDraw(player);
            }
        }
                                                                                                                                                                                                                                                                                                                            
        private void CommunityCardsDraw() // Puts the card in community pool
        {
            for (int i = 0; i <= 4; i++)
            {
                var temp = Deck.CardList[0];
                CommunityCards.Add(temp);
                Deck.CardList.RemoveAt(0);
                if (i > 2)
                {
                    CommunityCards[i].Active = false;
                }
            }
        }
        private void PlayerDraw(Player player) // Draws a card for the player
        {
            
            var temp = Deck.CardList[0];
            player.Hand.Cards.Add(temp);
            Deck.CardList.RemoveAt(0);
            
        }
        public void PlayerDeal() // Deals to each player
        {
            for (int i = 0; i < 1; i++)
            {
                foreach(var player in players)
                {
                    PlayerDraw(player);
                }
            }
        }
        public void TurnProgression() // Moves to the next turn
        {
            CommunityCards[Turn + 2].Active = true;
            Turn++;
            
        }
        public void RoundProgression() // Moves the blinds around and determines if players are still eligible to player
        {
            foreach(var player in players) // Sets each player to active/inactive if they're broke
            {
                if(player.Bank == 0)
                {
                    player.Active = false;
                }
                if(!player.Active && player.Bank > 0)
                {
                    player.Active = true;
                }
            }
            int smallBlindPosition = 0;
            int bigBlindPosition = 0;
            for (int i = 0; i < players.Count(); i++) // Locates position of big and small blind
            {
                if (players[i].SmallBlind)
                {
                    smallBlindPosition = i;
                }
                if (players[i].BigBlind)
                {
                    bigBlindPosition = i;
                }
            }
            for (int i = smallBlindPosition; i < players.Count() - 1; i++) // Moves the small blind to the next active player
            {
                if(i < players.Count() - 1)
                {
                    if (players[i].Active && !players[i].SmallBlind)
                    {
                        players[i].SmallBlind = true;
                        players[smallBlindPosition].SmallBlind = false;
                        break;
                    }
                }
                else
                {
                    if (players[i - (players.Count()-1)].Active && !players[i - (players.Count() - 1)].SmallBlind)
                    {
                        players[i - (players.Count() - 1)].SmallBlind = true;
                        players[smallBlindPosition].SmallBlind = false;
                        break;
                    }
                }
            }
            for (int i = bigBlindPosition; i < players.Count() - 1; i++) // Moves the big blind to the next active player
            {
                if (i < players.Count() - 1)
                {
                    if (players[i].Active && !players[i].BigBlind)
                    {
                        players[i].BigBlind = true;
                        players[bigBlindPosition].BigBlind = false;
                        break;
                    }
                }
                else
                {
                    if (players[i - (players.Count() - 1)].Active && !players[i - (players.Count() - 1)].BigBlind)
                    {
                        players[i - (players.Count() - 1)].BigBlind = true;
                        players[bigBlindPosition].BigBlind = false;
                        break;
                    }
                }
            }


        }
        public void WinningHand() // Evaluates hand and determines winner
        {
            Dictionary<Player, int> playerHandValues = new Dictionary<Player, int>();
            List<Player> winningPlayers = new List<Player>();
            foreach (var player in players)
            {
                if (player.Active)
                {
                    playerHandValues.Add(player, player.Hand.Evaluate());

                }
            }
            var winningHandValue = playerHandValues.Values.Max();
            foreach (var player in playerHandValues.Keys)
            {
                if (playerHandValues[player] == winningHandValue)
                {
                    winningPlayers.Add(player);
                }
            }
            if (Pots.Count() == 1) 
            {
                
                if (winningPlayers.Count() == 1) // one winner one pot
                {
                    winningPlayers[0].Bank += Pots[0].Size;
                    Pots.Clear();
                    Pots.Add(new Pot(players, 0));
                    Bet = 0;
                }
                else if (winningPlayers.Count() > 1) // multiple winners multiple pots
                {
                    var split = Pots[0].Size / winningPlayers.Count();

                    foreach (var player in winningPlayers)
                    {
                        player.Bank += split;
                    }

                    Pots.Clear();
                    Pots.Add(new Pot(players, 0));
                    Bet = 0;
                }
            }
            else
            {
                if (winningPlayers.Count() == 1) // One winner and multiple pots
                {
                    foreach(var pot in Pots) // one person case, pretty straightforward
                    {
                        if (pot.CompetingPlayers.Contains(winningPlayers[0])) //awards pot to winning player if in pot
                        {
                            winningPlayers[0].Bank += pot.Size;
                        }
                        else // split pot between others
                        {
                            var split = pot.Size / pot.CompetingPlayers.Count();
                            foreach (var player in pot.CompetingPlayers)
                            {
                                player.Bank += split;
                            }    
                        }
                    }
                    Pots.Clear();
                    Pots.Add(new Pot(players, 0));
                    Bet = 0;
                }
                else if (winningPlayers.Count() > 1) // If theres more than one winner AND more than one pot
                {
                    
                    foreach(var pot in Pots)
                    {
                        var tempPlayers = new List<Player>();
                        foreach(var player in pot.CompetingPlayers)
                        {
                            if (winningPlayers.Contains(player))
                            {
                                tempPlayers.Add(player);
                            }
                        }
                        if (tempPlayers.Count() == 1) // Pot awarded to sole winner in pot
                        {
                            tempPlayers[0].Bank += pot.Size;
                        }
                        else if(tempPlayers.Count() > 1) // Pot split between winners of pot
                        {
                            var split = pot.Size / tempPlayers.Count();
                            foreach(var player in tempPlayers)
                            {
                                player.Bank += split;
                            }
                        }
                        else // Pot is split between losers if no winner in pot
                        {
                            var split = pot.Size / pot.CompetingPlayers.Count();
                            foreach(var player in pot.CompetingPlayers)
                            {
                                player.Bank += split;
                            }
                        }
                        Pots.Clear();
                        Pots.Add(new Pot(players, 0));
                        Bet = 0;
                    }
                }
            }
            
        }
    }
}
