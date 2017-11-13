using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//add 2 more enemys, timer, make a cleaner end game
namespace BoxGameinClass
{
    public partial class Form1 : Form
    {
        private Rectangle Goal = new Rectangle(350, 650, 50, 50);
        private Rectangle Player = new Rectangle(350, 0, 50, 50);
        private Rectangle Enemy1 = new Rectangle(0,145,70,70);
        private Rectangle Enemy2 = new Rectangle(675,285, 70,70);
        private Rectangle Enemy3 = new Rectangle(0, 425, 70, 70);
        private Rectangle Enemy4 = new Rectangle(675, 550, 70, 70);
        string restart = "";
        int counter = 0;
        public Form1()
        {
            InitializeComponent();
            this.MaximumSize = new Size(750, 750);
            this.MinimumSize = new Size(750, 750);
            timer2.Start();
            clock.Text = "0";
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.SolidBrush mybrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(mybrush, Enemy1);
            mybrush.Dispose();

            System.Drawing.SolidBrush mybrush2 = new System.Drawing.SolidBrush(System.Drawing.Color.Orange);
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(mybrush2, Enemy2);
            mybrush2.Dispose();

            System.Drawing.SolidBrush mybrush3 = new System.Drawing.SolidBrush(System.Drawing.Color.Gold);
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(mybrush3, Player);
            mybrush3.Dispose();

            System.Drawing.SolidBrush mybrush4 = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(mybrush4, Goal);
            mybrush4.Dispose();

            System.Drawing.SolidBrush mybrush5 = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(mybrush5, Enemy3);
            mybrush4.Dispose();

            System.Drawing.SolidBrush mybrush6 = new System.Drawing.SolidBrush(System.Drawing.Color.Cyan);
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(mybrush6, Enemy4);
            mybrush4.Dispose();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int PlayerX = Player.Location.X;
            int PlayerY = Player.Location.Y;
            timer2.Start();

            switch (e.KeyData)
            {
                case Keys.Up:
                    Player.Location = new Point(PlayerX +=0, PlayerY -= 20);
                    this.Refresh();
                    break;
                case Keys.Down:
                    Player.Location = new Point(PlayerX += 0, PlayerY += 20);
                    this.Refresh();
                    break;
                case Keys.Left:
                    Player.Location = new Point(PlayerX -= 20, PlayerY += 0);
                    this.Refresh();
                    break;
                case Keys.Right:
                    Player.Location = new Point(PlayerX += 20, PlayerY += 0);
                    this.Refresh();
                    break;
            }
             if (Player.Location.X > 675)  //out of bounds scenarios
            {
                Player.Location = new Point(PlayerX -= 20, PlayerY += 0);
            }

            if (Player.Location.X < 1)
            {
                Player.Location = new Point(PlayerX += 20, PlayerY += 0);
            }

            if (Player.Location.Y > 675)
            {
                Player.Location = new Point(PlayerX += 0, PlayerY -= 20);
            }

            if (Player.Location.Y < 1)
            {
                Player.Location = new Point(PlayerX += 0, PlayerY += 20);
            }

            HitDetect();
            if (Player.IntersectsWith(Goal))  //hit detection for the goal
            {
                timer2.Stop();
                MessageBox.Show("You won with a time of "+clock.Text+" seconds");
                CheckPlayAgain();
                if (restart == "Yes")
                {
                    restart = "";
                  
                    counter = 0;
                    Player.Location = new Point(PlayerX = 350, PlayerY = 0);
                }
                if (restart == "No")
                {
                    counter = 0;
                    restart = "";
                    timer1.Stop();
                    this.Close();
                }
            }
           
        }
        public void HitDetect()
        {
            
            int playerX = Player.Location.X;
            int playerY = Player.Location.Y;
            if (Enemy1.IntersectsWith(Player))
            {
                Player.Location = new Point(playerX = 350, playerY = 0);
                MessageBox.Show("You lose");
                clock.Text = "0";
                counter = 0;
                
            }
            if (Enemy2.IntersectsWith(Player))
            {
                Player.Location = new Point(playerX = 350, playerY = 0);
                MessageBox.Show("You lose");
                clock.Text = "0";
                counter = 0;
            }
            if (Enemy3.IntersectsWith(Player))
            {
                Player.Location = new Point(playerX = 350, playerY = 0);
                MessageBox.Show("You lose");
                clock.Text = "0";
                counter = 0;
            }
            if (Enemy4.IntersectsWith(Player))
            {
                Player.Location = new Point(playerX = 350, playerY = 0);
                MessageBox.Show("You lose");
                clock.Text = "0";
                counter = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int ex1 = Enemy1.Location.X;
            int ey1 = Enemy1.Location.Y;
            
            if (ex1>675)
            {
                Enemy1.Location = new Point(ex1= 0, ey1 =150 );
            }
            Enemy1.Location = new Point(ex1 += 30, ey1 += 0);
            this.Refresh();

            int ex2 = Enemy2.Location.X;
            int ey2 = Enemy2.Location.Y;

            if (ex2 <0)
            {
                Enemy2.Location = new Point(ex2 = 675, ey2 += 0);
            }
            Enemy2.Location = new Point(ex2 -= 30, ey2 += 0);
            this.Refresh();

            int ex3 = Enemy3.Location.X;
            int ey3 = Enemy3.Location.Y;

            if (ex3 > 675)
            {
                Enemy3.Location = new Point(ex3 = 0, ey3 = 425);
            }
            Enemy3.Location = new Point(ex3 += 30, ey3 += 0);
            this.Refresh();

            int ex4 = Enemy4.Location.X;
            int ey4 = Enemy4.Location.Y;

            if (ex4 < 0)
            {
                Enemy4.Location = new Point(ex4 = 675, ey4 += 0);
            }
            Enemy4.Location = new Point(ex4 -= 30, ey4 += 0);
            this.Refresh();

            HitDetect();
            
        }

        public void CheckPlayAgain()
        { 
            switch (MessageBox.Show("Do you want to play again? ","Frogger",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    restart ="Yes";
                    break;
                case DialogResult.No:
                    restart = "No";
                    break;

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            counter++;
            clock.Text = counter + "";
        }
    }
}   

