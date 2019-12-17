using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokerLibrary;

namespace PokerGUI
{
    public partial class Inputs : Form
    {
        public Inputs()
        {
            InitializeComponent();
            
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            try
            {
                PokerGUI.NumberOfPlayers = Int32.Parse(playersText.Text);
                PokerGUI.PlayerPotSize = Decimal.Parse(bankRollText.Text);
                PokerGUI.currentGame = new Game(PokerGUI.NumberOfPlayers, PokerGUI.PlayerPotSize);
                PokerGUI.pokerGUI.StartUp();
                Close();
            }
            catch(Exception a)
            {
                MessageBox.Show("Please enter valid inputs");
                //MessageBox.Show(a.Message);
            }
            
        }
    }
}
