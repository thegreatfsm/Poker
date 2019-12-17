using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    // Game consists of Deck and Community Cards, as well as has access to each player. Method for giving money to player for winning hand.
    // player to left of small blind goes first after flop
    // Implement side pot and blinds(done), then work on UI game logic almost done, work on checking if each player has bet, requires computer ai.
    public class Game 
    {
        
        private int numberOfPlayers;
        public int Turn { get; set; }
        public List<Pot> Pots { get; set; }
        public Pot ActivePot { get; set; }
        public decimal TotalMaxBet { get; set; }
        public decimal CurrentMaxBet { get; set; }
        public decimal BigBlind { get; set; }
        public decimal SmallBlind { get; set; }
        public Deck Deck { get; set; }
        public List<Player> Players { get; set; }
        public List<Card> CommunityCards { get; set; }
        public Dictionary<Player, decimal> PlayersBets { get; set; }

        public Game (int aNumberOfPlayers, decimal PlayerBank)
        {
            numberOfPlayers = aNumberOfPlayers;
            Turn = 0;
            PlayersBets = new Dictionary<Player, decimal>();


            BigBlind = Math.Floor(PlayerBank / 20);
            SmallBlind = Math.Floor(BigBlind / 2);
            TotalMaxBet = BigBlind;
            Deck = new Deck();
            Deck.Shuffle();
            Players = new List<Player>();
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                if (i == 1)
                {
                    Players.Add(new Player(PlayerBank, i));
                    
                }
                else
                {
                    Players.Add(new ComputerPlayer(PlayerBank, i));
                }
            }
            var dealerPosition = new Random().Next(0, numberOfPlayers);
            Players[dealerPosition].Dealer = true;
            var smallBlindPosition = (dealerPosition + 1) > (numberOfPlayers - 1) ? dealerPosition - numberOfPlayers + 1 : dealerPosition + 1;
            var bigBlindPosition = (dealerPosition + 2) > (numberOfPlayers - 1) ? dealerPosition - numberOfPlayers + 2 : dealerPosition + 2;
            Players[smallBlindPosition].SmallBlind = true;
            Players[smallBlindPosition].TotalBet = SmallBlind;
            Players[smallBlindPosition].CurrentBet = SmallBlind;
            PlayersBets.Add(Players[smallBlindPosition], Players[smallBlindPosition].TotalBet);
            Players[smallBlindPosition].Bank -= SmallBlind;
            Players[bigBlindPosition].BigBlind = true;
            Players[bigBlindPosition].TotalBet = BigBlind;
            Players[bigBlindPosition].CurrentBet = BigBlind;
            PlayersBets.Add(Players[bigBlindPosition], Players[bigBlindPosition].TotalBet);
            Players[bigBlindPosition].Bank -= BigBlind;
            Pots = new List<Pot>();
            Pots.Add(ActivePot = new Pot(Players, 0));
            ActivePot.Size += SmallBlind;
            ActivePot.Size += BigBlind;
            CommunityCards = new List<Card>();
            PlayerDeal();
        }
                                                                                                                                                                                                                                                                                                                       
        private void CommunityCardsDraw() // Puts the card in community pool
        {
                var temp = Deck.CardList[0];
                CommunityCards.Add(temp);
                Deck.CardList.RemoveAt(0);
        }
        private void CommunityCardsDeal() // Deals the initial cards
        {
            for(int i =0; i<= 2; i++)
            {
                CommunityCardsDraw();
            }
        }
        private void PlayerDraw(Player player) // Draws a card for the player
        {
            
            var temp = Deck.CardList[0];
            player.Hand.Cards.Add(temp);
            player.OriginalHand.Cards.Add(temp);
            Deck.CardList.RemoveAt(0);
            
        }
        private void PlayerDeal() // Deals to each player
        {
            for (int i = 0; i < 2; i++)
            {
                foreach(var player in ActivePot.CompetingPlayers)
                {
                    PlayerDraw(player);
                }
            }
        }
        public void TurnProgression() // Moves to the next turn
        {
            if(Turn == 0)
            {
                CommunityCardsDeal();
            }
            else
            {
                CommunityCardsDraw();
            }
            Turn++;
            
        }
        public void RoundProgression() // --CURENTLY THE CAUSE OF THE CRASHES WHEN BLINDS DON'T MOVE AROUND CORRECTLY--Ends the round, moves the blinds around and determines if players are still eligible to play
        {
            Pots.Clear(); // Clears out the pots
            Deck = new Deck();
            PlayersBets.Clear();
            Deck.Shuffle();
            CommunityCards.Clear();
            Turn = 0;
            foreach (var player in Players) // Sets each player to active/inactive if they're broke
            {
                player.TotalBet = 0;
                player.Hand.Cards.Clear();
                player.OriginalHand.Cards.Clear();
                if (player.Bank <= 0)
                {
                    player.Active = false;
                }
                if(!player.Active && player.Bank > 0)
                {
                    player.Active = true;
                    player.Fold = false;
                }
            }
            int smallBlindPosition = 0;
            int bigBlindPosition = 0;
            int dealerPosition = 0;
            for (int i = 0; i < Players.Count(); i++) // Locates position of big and small blind and dealer
            {
                if (Players[i].SmallBlind)
                {
                    smallBlindPosition = i;
                }
                if (Players[i].BigBlind)
                {
                    bigBlindPosition = i;
                }
                if (Players[i].Dealer)
                {
                    dealerPosition = i;
                }
            }

            for (int i = dealerPosition; true; i++) // Moves the dealer to the next active player
            {
                i = i == Players.Count() ? 0 : i;
                if (Players[i].Active && !Players[i].Dealer)
                {
                    Players[i].Dealer = true;
                    Players[dealerPosition].Dealer = false;
                    dealerPosition = i;
                    break;
                }
            }

            for (int i = smallBlindPosition; true; i++) // Moves the small blind to the next active player
            {
                i = i == Players.Count() ? 0 : i;
                if (Players[i].Active && !Players[i].SmallBlind)
                {
                    Players[i].SmallBlind = true;
                    Players[smallBlindPosition].SmallBlind = false;
                    smallBlindPosition = i;
                    break;
                }
            }

            for (int i = bigBlindPosition; true; i++) // Moves the big blind to the next active player
            {
                i = i == Players.Count() ? 0 : i;
                if (Players[i].Active && !Players[i].BigBlind)
                {
                    Players[i].BigBlind = true;
                    Players[bigBlindPosition].BigBlind = false;
                    bigBlindPosition = i;
                    break;
                }
            }


            // --- Creates new pot ----
            var ActivePlayers = new List<Player>();
            foreach(var player in Players)
            {
                if (player.Active)
                {
                    ActivePlayers.Add(player);
                }
            }
            Pots.Add(ActivePot = new Pot(ActivePlayers, 0));
            Players[bigBlindPosition].TotalBet = BigBlind;
            Players[bigBlindPosition].CurrentBet = BigBlind;
            Players[bigBlindPosition].Bank -= BigBlind;
            PlayersBets.Add(Players[bigBlindPosition], Players[bigBlindPosition].TotalBet);
            ActivePot.Size += BigBlind;
            Players[smallBlindPosition].TotalBet = SmallBlind;
            Players[smallBlindPosition].CurrentBet = SmallBlind;
            Players[smallBlindPosition].Bank -= SmallBlind;
            PlayersBets.Add(Players[smallBlindPosition], Players[smallBlindPosition].TotalBet);
            ActivePot.Size += SmallBlind;
            PlayerDeal();
            TotalMaxBet = BigBlind;
            

        }
        public int ActivePlayers()
        {
            int activePlayers = 0;
            foreach (var player in Players)
            {
                if (player.Active)
                {
                    activePlayers++;
                }
            }
            return activePlayers;
        }
        public void ClearBets()
        {
            foreach (var player in Players)
            {
                player.CurrentBet = 0;
            }
        }
        public void WinningHand(Pot pot) // Evaluates hands of players in a pot
        {
            Dictionary<Player, int> playerHandValues = new Dictionary<Player, int>();
            List<Player> winningPlayers = new List<Player>();

            foreach(var player in pot.CompetingPlayers) // Checks hand of each player in the pot
            {
                if (!player.Fold)
                {
                    player.FindBestHand(CommunityCards);
                    playerHandValues.Add(player, player.Hand.Evaluate());
                }           
            }
            var winningHandValue = playerHandValues.Values.Max(); // Best hand value
            foreach(var player in pot.CompetingPlayers) // Finds winners
            {
                if (player.Fold)
                {
                    continue;
                }
                if(playerHandValues[player] == winningHandValue)
                {
                    winningPlayers.Add(player);
                    pot.WinningPlayers.Add(player);
                }
            }
            var split = pot.Size / winningPlayers.Count(); // Splits the pot if needed
            foreach (var player in winningPlayers) // Awards pot to winner(s)
            {
                player.Bank += split;
            }

        }
        public void PlayerFold(Player player)
        {
            foreach(var pot in Pots)
            {
                pot.CompetingPlayers.Remove(player);
            }
        }
    }
}
