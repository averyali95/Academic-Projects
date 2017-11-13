using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace PongGame
{
    public partial class Form1 : Form
           {
            public int speed_left = 4;
            public int speed_top = 4;
            public int points = 0;
            public int speed_inc = 1;
            
            public int balls_left = 3;

            public Form1()
            {
                InitializeComponent();
                timer1.Enabled = true;
                Cursor.Hide();

                this.FormBorderStyle = FormBorderStyle.None;
                this.TopMost = true;
                this.Bounds = Screen.PrimaryScreen.Bounds;

                racket.Top = playground.Bottom - (playground.Bottom / 10);

                lbl_gameover.Left = (playground.Width / 2) - (lbl_gameover.Width / 2);
                lbl_gameover.Top = (playground.Height / 2) - (lbl_gameover.Height / 2);
                lbl_gameover.Visible = false;

            }

            private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Escape) { this.Close(); }
                if (e.KeyCode == Keys.F1)   //reset everything
                {
                    ball.Top = 50;
                    ball.Left = 50;
                    points = 0;
                    speed_left = 4;
                    speed_top = 4;
                    speed_inc = 1;
                    lbl_points.Text = "0";
                    lbl_gameover.Visible = false;
                    playground.BackCol7or = Color.White;
                    timer1.Enabled = true;
                }
            }

            private void timer1_Tick(object sender, EventArgs e)
            {
                ball.Left = ball.Left + speed_left;
                ball.Top = ball.Top + speed_top;

                racket.Left = Cursor.Position.X - (racket.Width / 2);
                if (racket.Left < 0) { racket.Left = 0; }
                if ((racket.Left + racket.Width) >= playground.Width)
                {
                    racket.Left = playground.Width - racket.Width;
                }

                if(ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >=racket.Left && ball.Right <= racket.Right)
                {
                    speed_top = speed_top + speed_inc;
                    speed_left = speed_left + speed_inc;
                    speed_top = -speed_top;
                    points = points + 1;
                    lbl_points.Text = points.ToString();
                    //Console.Beep();
                    SystemSounds.Asterisk.Play();

                    Random backgroundcolor = new Random();
                    playground.BackColor = Color.FromArgb(backgroundcolor.Next(150,250),backgroundcolor.Next(150,250),backgroundcolor.Next(150,250));

                }
                if (ball.Left <= playground.Left)
                { speed_left = -speed_left;
                }
                if (ball.Right >= playground.Right)
                {
                    speed_left = -speed_left;
                }
                if (ball.Top <= playground.Top)
                {
                    speed_top = -speed_top;
                }
                if (ball.Bottom >= playground.Bottom)
                {
                    timer1.Enabled = false;
                    lbl_gameover.Visible = true;
                    //this.Close();
                }
            }
        }
    }