using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The code below was written with assistance from a YouTube video.
        // Link for the video: https://www.youtube.com/watch?app=desktop&v=vFE6pJmtA44

        public int player = 2; // Even = X Turn, Odd = O turn.
        public int turns = 0; // Counting turns.
        // Counting wins for both players and draws.
        public int s1 = 0;
        public int s2 = 0;
        public int sd = 0;

        private void buttonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "")
            {
                if (player % 2 == 0)
                {
                    button.Text = "X";
                    player++;
                    turns++;
                }
                else
                {
                    button.Text = "O";
                    player++;
                    turns++;
                }
                if (CheckDraw())
                {
                    MessageBox.Show("Tie Game!");
                    sd++;
                    New_Game();
                }
                if (CheckWinner())
                {
                    if (button.Text == "X")
                    {
                        MessageBox.Show("X Won!");
                        s1++;
                        New_Game();
                    }
                    else 
                    {
                        MessageBox.Show("O Won!");
                        s2++;
                        New_Game();
                    }
                }
            }
            
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XWin.Text = "X: " + s1;
            OWin.Text = "O: " + s2;
            Draw.Text = "Draws: " + sd;
        }

        void New_Game()
        {
            player = 2;
            turns = 0;
            A11.Text = A12.Text = A13.Text = A21.Text = A22.Text = A23.Text = A31.Text = A32.Text = A33.Text = "";
            XWin.Text = "X: " + s1;
            OWin.Text = "O: " + s2;
            Draw.Text = "Draws: " + sd;
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            New_Game();
        }

        bool CheckDraw()
        {
            if (turns == 9 && !CheckWinner())
                return true;
            else
                return false;
        }

        bool CheckWinner()
        {
            // Check Rows.
            if (A11.Text == A12.Text && A12.Text == A13.Text && A11.Text != "")
                return true;
            else if (A21.Text == A22.Text && A22.Text == A23.Text && A21.Text != "")
                return true;
            else if (A31.Text == A32.Text && A32.Text == A33.Text && A31.Text != "")
                return true;

            // Check Columns.
            if (A11.Text == A21.Text && A21.Text == A31.Text && A11.Text != "")
                return true;
            else if (A12.Text == A22.Text && A22.Text == A32.Text && A12.Text != "")
                return true;
            else if (A13.Text == A23.Text && A23.Text == A33.Text && A13.Text != "")
                return true;

            // Check Diagonals
            if (A11.Text == A22.Text && A22.Text == A33.Text && A11.Text != "")
                return true;
            else if (A31.Text == A22.Text && A22.Text == A13.Text && A31.Text != "")
                return true;
            else
                return false;


        }

        private void Reset_Click(object sender, EventArgs e)
        {
            s1 = s2 = sd = 0;
            New_Game();
        }
    }
}
