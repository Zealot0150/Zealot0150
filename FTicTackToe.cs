using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{

    public partial class FTicTacToe : Form
    {
        string player1 = "X";
        string player2 = "O";
        bool IsPlayer1 = true;
        public FTicTacToe()
        {
            InitializeComponent();
            this.CenterToScreen();
            // Welcome message
            MessageBox.Show("Hej, välkommen till 3 i rad, må bästa person vinna\n Den första personen börjar med X, den andra får O, klicka den ruta ni vill ha");

        }

        private void buttonClick(object sender, EventArgs e)
        {
            if (changeStatus((Button)sender, IsPlayer1 ? player1 : player2))
            {
                if (CheckWin(IsPlayer1 ? player1 : player2))
                {
                    MessageBox.Show("Spelaren med " + player1 + " vann");
                    ClearButtons();
                  }
                else
                    IsPlayer1 = !IsPlayer1;
                }
            if (EndOfGame())
                MessageBox.Show("Spelet slut, slutade oavgjort");
        }
        private void ClearButtons()
        {
            button1.Text =
                button2.Text =
                button3.Text =
                button4.Text =
                button5.Text =
                button6.Text =
                button7.Text =
                button8.Text =
                button9.Text = "";
            IsPlayer1 = true;

        }


        private bool changeStatus(Button b, string player)
        {
            if (b.Text == "")
            {
                b.Text = player;
                return true;
            }
            else
                return false;
        }


        private bool CheckWin(string player)
        {
            // Horisontellt
            if (
                ((button1.Text == player) & (button2.Text == player) & (button3.Text == player))
                 )
                return true;

            if (
                ((button4.Text == player) & (button5.Text == player) & (button6.Text == player))
                 )
                return true;

            if (
                ((button7.Text == player) & (button8.Text == player) & (button9.Text == player))
                 )
                return true;

            // Vågrätt
            if (
                ((button1.Text == player) & (button4.Text == player) & (button7.Text == player))
                 )
                return true;

            if (
                ((button2.Text == player) & (button5.Text == player) & (button8.Text == player))
                 )
                return true;


            if (
                ((button3.Text == player) & (button6.Text == player) & (button9.Text == player))
                 )
                return true;

            // Dia
            if (
                ((button1.Text == player) & (button5.Text == player) & (button9.Text == player))
                 )
                return true;
            if (
                ((button3.Text == player) & (button5.Text == player) & (button7.Text == player))
                 )
                return true;


            return false;
        }

        private bool EndOfGame()
        {
            if ((button1.Text != "")
                &
                (button2.Text != "")
                &
                (button3.Text != "")
                &
                (button4.Text != "")
                &
                (button5.Text != "")
                &
                (button6.Text != "")
                &
                (button7.Text != "")
                &
                (button8.Text != "")
                &
                (button9.Text != ""))
                return true;
            return false;

        }
    }
}
