using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerLibrary;
using System.Windows.Forms;

namespace PokerGUI
{
    public partial class winningHandForm : Form
    {
        private List<Player> winningPlayers;
        public winningHandForm(Pot pot)
        {
            InitializeComponent();
            winningPlayers = pot.WinningPlayers;
            potSizeLabel.Text = $"Pot Size: {pot.Size}";
            for(int i = 0; i < winningPlayers.Count(); i++)
            {
                CreateWinningGroupBox(i);
            }
        }

        public void CreateWinningGroupBox(int iteration)
        {
            if(iteration == 0)
            {
                winningPlayerGroupBox.Text = $"Player {winningPlayers[0].PlayerNumber}:";
                var hand = winningPlayers[0].Hand;
                int loopCount = 0;
                foreach(var control in winningPlayerGroupBox.Controls)
                {
                    if(control is PictureBox)
                    {
                        PictureBox pbox = control as PictureBox;
                        pbox.SizeMode = PictureBoxSizeMode.StretchImage;
                        pbox.Image = hand.Cards[loopCount++].CardImage;
                    }
                }
            }
            else
            {
                var player = winningPlayers[iteration];
                GroupBox newGB = new GroupBox();
                this.Controls.Add(newGB);
                newGB.Size = winningPlayerGroupBox.Size;
                newGB.Text = $"Player {player.PlayerNumber}";
                this.Height += 230;
                newGB.Location = new Point(7, 30 + 220 * iteration);
                PictureBox[] cardImages = new PictureBox[5];

                for(int i = 0; i < cardImages.Length; i++)
                {
                    var pb = new PictureBox();
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb.Width = 104;
                    pb.Height = 161;
                    cardImages[i] = pb;
                    pb.Image = player.Hand.Cards[i].CardImage;
                    newGB.Controls.Add(pb);
                }

                cardImages[0].Location = new Point(45, 31);
                cardImages[1].Location = new Point(174, 31);
                cardImages[2].Location = new Point(302, 31);
                cardImages[3].Location = new Point(428, 31);
                cardImages[4].Location = new Point(550, 31);


            }
        }
    }
}
