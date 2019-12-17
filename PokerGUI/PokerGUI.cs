using PokerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerGUI // Need to add Pot logic, Computer AI and overall game logic controls. 
{
    public partial class PokerGUI : Form
    {
        public static int NumberOfPlayers = 0;
        public static decimal PlayerPotSize = 0;
        public static Game currentGame;
        public static PokerGUI pokerGUI;
        public static bool betButtonPressed;
        public static bool checkButtonPressed;
        public static bool foldButtonPressed;
        private System.Threading.Thread mainThr;
       
        public PokerGUI()
        {
            InitializeComponent();
            betButton.Enabled = false;
            foldButton.Enabled = false;
            checkButton.Enabled = false;
            var inputs = new Inputs();
            pokerGUI = this;
            mainThr = System.Threading.Thread.CurrentThread;
            inputs.Show();
        }

        private void BetButton_Click(object sender, EventArgs e) // currently tests if GetCombination works
        {
            try
            {
                var bet = Decimal.Parse(betTextBox.Text);
                Bet(bet);
            }
            catch
            {
                MessageBox.Show("Please enter a valid bet");
            }
            betButtonPressed = true;
            
        }

        public async void StartUp()
        {
            
            foreach(var player in currentGame.Players)
            {
                playersListBox.Items.Add(player);
            }
            await Task.Run(() => GameProgression());
        }
        private void UpdatePlayers() // Updates the list box with all info
        {
            MethodInvoker methodInvoker = delegate ()
            {
                playersListBox.Items.Clear();

                foreach (var player in currentGame.Players)
                {
                    playersListBox.Items.Add(player);
                }
            };
            playersListBox.Invoke(methodInvoker);
            
        }
        private void Bet(decimal bet) // bets for player and runs new pot check
        {
            var player = currentGame.Players[0];
            var oldGameBet = currentGame.TotalMaxBet;
            if (bet + player.TotalBet < currentGame.TotalMaxBet)
            {
                throw new Exception("Please enter a valid amount");
            }
            if (bet >= player.Bank) // ALL IN
            {
                player.TotalBet += player.Bank;
                player.CurrentBet += player.Bank;
                currentGame.ActivePot.Size += player.Bank; 
                player.Bank = 0;
                player.Active = false;
                
            }
            else // Adjust bank and bet accordingly
            {
                player.TotalBet += bet;
                player.CurrentBet += bet;
                currentGame.ActivePot.Size += bet;
                player.Bank -= bet;
            }
            currentGame.TotalMaxBet = player.TotalBet > currentGame.TotalMaxBet ? player.TotalBet : currentGame.TotalMaxBet;
            /*if(currentGame.Bet > oldGameBet)
            {
                NewPotCheck(currentGame.Bet - oldGameBet, player);
            }*/
        }
        private void NewPotCheck(decimal potSize, Player playerCheck) //Creates a new pot if necessary
        {
            bool newPotNeeded = false;
            List<Player> carryOverPlayers = new List<Player>();
            foreach (var player in currentGame.ActivePot.CompetingPlayers)
            {
                if (!player.Active && player != playerCheck)
                {
                    newPotNeeded = true;
                }
                else
                {
                    carryOverPlayers.Add(player);
                }
            }
            if (!newPotNeeded)
            {
                return;
            }
            else
            {
                currentGame.Pots.Add(currentGame.ActivePot = new Pot(carryOverPlayers, potSize));
            }

        }
        private void NewPot(Dictionary<Player, decimal> PlayerBets)
        {
            List<Player> carryOverPlayers = new List<Player>();
            decimal potSize = 0;
            Pot oldPot = currentGame.ActivePot;
            
            while (PlayerBets.Values.Min() != PlayerBets.Values.Max()) // check for smaller bets that go in old pot
            {
                var minBet = PlayerBets.Values.Min();
                
                
                for (int i = 0; i < oldPot.CompetingPlayers.Count(); i++)
                {
                    if(PlayerBets[oldPot.CompetingPlayers[i]] == minBet)
                    {
                        PlayerBets.Remove(oldPot.CompetingPlayers[i]);
                    }
                    else
                    {
                        carryOverPlayers.Add(oldPot.CompetingPlayers[i]);
                        PlayerBets[oldPot.CompetingPlayers[i]] -= minBet;
                        oldPot.Size -= PlayerBets[oldPot.CompetingPlayers[i]];
                        if(PlayerBets[oldPot.CompetingPlayers[i]] == 0)
                        {
                            PlayerBets.Remove(oldPot.CompetingPlayers[i]);
                        }
                    }
                }
                currentGame.Pots.Add(currentGame.ActivePot = new Pot(carryOverPlayers, PlayerBets.Values.Sum()));
                carryOverPlayers.Clear();
                oldPot = currentGame.ActivePot;
                
                /*foreach(var player in PlayerBets.Keys)
                {
                    if(PlayerBets[player] == PlayerBets.Values.Min())
                    {
                        PlayerBets.Remove(player);
                    }
                    else
                    {
                        carryOverPlayers.Add(player);
                        PlayerBets[player]
                        currentGame.ActivePot.Size -= 
                    }
                }*/
            }
            /*foreach(var player in PlayerBets.Keys)
            {
                potSize += PlayerBets[player];
                carryOverPlayers.Add(player);
            }*/
        }
        private void BettingProgression() // Use async to bring buttons up when needed, is used to make sure each player in the active pot gets a chance to bet
        {
            var human = currentGame.Players[0];
            int first = FirstPlayerPosition(); 
            int loopCount = 0;
            Pot checkPot = currentGame.ActivePot;
            List<Player> activePlayers = new List<Player>(checkPot.CompetingPlayers);
            
            int playersCount = activePlayers.Count();
            decimal largestBet = 0;
            do
            {
                for(int i = first; loopCount < playersCount; i++) // Looks at  players of competing pot
                {
                    i = i == playersCount ? 0 : i;
                    if (activePlayers[i] == human && human.Active) // human player turn
                    {
                        var oldBet = currentGame.TotalMaxBet;
                        var playerOld = human.CurrentBet;
                        PlayerActionPolling();
                        UpdatePlayers();
                        if (!currentGame.PlayersBets.ContainsKey(human))
                        {
                            currentGame.PlayersBets.Add(human, human.CurrentBet);
                        }
                        else
                        {
                            currentGame.PlayersBets[human] += human.CurrentBet - playerOld;
                        }
                        if(human.TotalBet > oldBet)
                        {
                            loopCount = 0;
                            largestBet = human.CurrentBet;
                        }
                        largestBet = human.CurrentBet > largestBet ? human.CurrentBet : largestBet;
                    }
                    else if (activePlayers[i].Active) // Computer action
                    {
                        var oldBet = currentGame.TotalMaxBet;
                        var computer = (ComputerPlayer)activePlayers[i];
                        var playerOld = computer.TotalBet;
                        computer.Check(currentGame);
                        //computer ai bet/fold/check
                        UpdatePlayers();
                        if (!currentGame.PlayersBets.ContainsKey(computer))
                        {
                            currentGame.PlayersBets.Add(computer, computer.TotalBet - playerOld);
                        }
                        else
                        {
                            currentGame.PlayersBets[computer] += computer.TotalBet - playerOld;
                        }
                        if (computer.TotalBet > oldBet)
                        {
                            loopCount = 0;
                            largestBet = computer.CurrentBet;
                        }
                        largestBet = computer.CurrentBet > largestBet ? computer.CurrentBet : largestBet;
                    }
                    loopCount++;
                }
                decimal total = 0;
                int nonFold = 0;
                foreach(var player in currentGame.PlayersBets.Keys)
                {
                    if (!player.Fold)
                    {
                        nonFold++;
                        total += currentGame.PlayersBets[player];
                    }
                }
                if(largestBet * nonFold > total) // works so far, need more testing
                {
                    NewPot(currentGame.PlayersBets);
                }
                loopCount = 0;
                checkPot = currentGame.ActivePot;
                activePlayers = new List<Player>(checkPot.CompetingPlayers);
                playersCount = currentGame.ActivePot.CompetingPlayers.Count();
                currentGame.PlayersBets.Clear();
                currentGame.ClearBets();
                first = FirstPlayerPosition();

            } while (!BetsMade());
        }
        private void PlayerActionPolling() // utilize to determine betting order 
        {
            var buttons = new[] { betButton, foldButton, checkButton };
           
            foreach(var button in buttons)
            {
                if (button.InvokeRequired)
                {
                    MethodInvoker methodInvokerDelegate = delegate ()
                    {
                        button.Enabled = true;
                    };
                    button.Invoke(methodInvokerDelegate);
                }
                else
                {
                    button.Enabled = true;
                }
            }
            betButtonPressed = false;
            checkButtonPressed = false;
            foldButtonPressed = false;

            while(!betButtonPressed && !checkButtonPressed && !foldButtonPressed)
            {
                System.Threading.Thread.Sleep(50);
            }

            foreach (var button in buttons)
            {
                if (button.InvokeRequired)
                {
                    MethodInvoker methodInvokerDelegate = delegate ()
                    {
                        button.Enabled = false;
                    };
                    button.Invoke(methodInvokerDelegate);
                }
                else
                {
                    button.Enabled = false;
                }
            }
        }
        private bool BetsMade() // Sees if a betting round can end
        {
            var bet = currentGame.TotalMaxBet;
            bool betsMade = true;
            foreach (var player in currentGame.ActivePot.CompetingPlayers)
            {
                if(player.TotalBet < bet && !player.Fold)
                {
                    betsMade = false;
                    break;
                }
            }
            return betsMade;
        }
        private int FirstPlayerPosition() // Locates first player
        {
            
            Player firstPlayer = null;
            int i = 0;
            if(currentGame.Turn == 0)
            {
                bool passedBigBlind = false;
                while (!passedBigBlind || firstPlayer == null)
                {
                    i = i == currentGame.Players.Count() ? 0 : i;
                    if (passedBigBlind && currentGame.ActivePot.CompetingPlayers.Contains(currentGame.Players[i]))
                    {
                        firstPlayer = currentGame.Players[i];
                    }
                    if (currentGame.Players[i].BigBlind)
                    {
                        passedBigBlind = true;
                    }
                    i++;
                }
            }
            else
            {
                bool passedDealer = false;
                while (!passedDealer || firstPlayer == null)
                {
                    i = i == currentGame.Players.Count() ? 0 : i;
                    if (passedDealer && currentGame.ActivePot.CompetingPlayers.Contains(currentGame.Players[i]))
                    {
                        firstPlayer = currentGame.Players[i];
                    }
                    if (currentGame.Players[i].Dealer)
                    {
                        passedDealer = true;
                    }
                    i++;
                }
            }
            
            return currentGame.ActivePot.CompetingPlayers.IndexOf(firstPlayer);
        }
        private void PokerGUI_Load(object sender, EventArgs e)
        {

            
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            var player = currentGame.Players[0];
            try
            {
                Bet(currentGame.TotalMaxBet - player.TotalBet);
            }
            catch
            {
                MessageBox.Show("Please enter a valid bet");
            }
            checkButtonPressed = true;
        }

        private void FoldButton_Click(object sender, EventArgs e)
        {
            var player = currentGame.Players[0];
            player.Active = false;
            player.Fold = true;
            //currentGame.PlayerFold(player);
            foldButtonPressed = true;
        }
        private void AddCardImages()
        {
            var player = currentGame.Players[0];
            PictureBox[] communityCardImages = {communityCard1, communityCard2, communityCard3, communityCard4, communityCard5 };
            PictureBox[] cardImages = { playerCard1, playerCard2 };
            switch (currentGame.Turn)
            {
                case 0:
                    /*foreach (var item in communityCardImages)
                    {

                        MethodInvoker methodInvokerDelegate = delegate ()
                        {
                            item.Image =
                        };
                        
                    }*/
                    var loopNumber = 0;
                    foreach (var item in cardImages)
                    {
                        
                        MethodInvoker methodInvokerDelegate = delegate ()
                        {
                            item.Image = player.Hand.Cards[loopNumber].CardImage;
                            item.SizeMode = PictureBoxSizeMode.StretchImage;
                            //item.CreateGraphics();
                        };
                        item.Invoke(methodInvokerDelegate);
                        loopNumber++;
                    }
                    break;
                case 1:
                    
                    for (int i = 0; i <= 2; i++)
                    {
                        MethodInvoker methodInvokerDelegate2 = delegate ()
                        {
                            communityCardImages[i].Image = currentGame.CommunityCards[i].CardImage;
                            communityCardImages[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        };
                        communityCardImages[i].Invoke(methodInvokerDelegate2);
                    }
                    break;
                case 2:
                    MethodInvoker methodInvokerDelegate3 = delegate ()
                    {
                        communityCardImages[3].Image = currentGame.CommunityCards[3].CardImage;
                        communityCardImages[3].SizeMode = PictureBoxSizeMode.StretchImage;
                    };
                    communityCardImages[3].Invoke(methodInvokerDelegate3);
                    break;
                case 3:
                    MethodInvoker methodInvokerDelegate4 = delegate ()
                    {
                        communityCardImages[4].Image = currentGame.CommunityCards[4].CardImage;
                        communityCardImages[4].SizeMode = PictureBoxSizeMode.StretchImage;
                    };
                    communityCardImages[4].Invoke(methodInvokerDelegate4);
                    break;
                

            }
        }
        private void ClearCommunityCards()
        {
            PictureBox[] communityCardImages = { communityCard1, communityCard2, communityCard3, communityCard4, communityCard5 };
            foreach(var item in communityCardImages)
            {
                MethodInvoker methodInvokerDelegate = delegate ()
                {
                    item.Image = null;
                };
                item.Invoke(methodInvokerDelegate);
            }
        }
        private void CreateWinningHandGui(Pot pot)
        {
            //new System.Threading.Thread(() => new winningHandForm(pot).ShowDialog()).Start();
            Invoke((Action)(() => { new winningHandForm(pot).Show(); }));
            //var winningHandGui = new winningHandForm(pot);
            //winningHandGui.Show();
        }
        private void GameProgression()
        {
            var player = currentGame.Players[0];

            while (player.Active && currentGame.ActivePlayers() > 1)
            {
                AddCardImages();
                BettingProgression();

                while (currentGame.Turn != 3 && currentGame.ActivePot.CompetingPlayers.Count() > 1)
                {
                    currentGame.TurnProgression();
                    AddCardImages();
                    BettingProgression();

                }
                foreach (var pot in currentGame.Pots)
                {
                    currentGame.WinningHand(pot);
                    CreateWinningHandGui(pot);
                    
                }
                ClearCommunityCards();

                currentGame.RoundProgression();
                UpdatePlayers();
            }
            if (player.Active)
            {
                MessageBox.Show("You win!");
            }
            else
            {
                MessageBox.Show("You lose.");
            }
        }
    }
}
