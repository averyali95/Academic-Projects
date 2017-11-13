using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game
{
    public partial class Form1 : Form
    {
       
        public int speed_left = 4;
        public int speed_top = 4;
        public int points = 0;
        public int speed_inc = 1;
        
        public Form1()
        {
            InitializeComponent();
            gameover.Visible = false;
            timer1.Enabled = true;
            Cursor.Hide(); //hide cursor on screen
            this.FormBorderStyle = FormBorderStyle.None; //remove any borders from screen
            this.TopMost = true; //makes this form frontmost
            this.Bounds = Screen.PrimaryScreen.Bounds; //set full screen

            racket.Top = playground.Bottom - (playground.Bottom / 10);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ball.Left += speed_left;
            ball.Top += speed_top;
        
            racket.Left = Cursor.Position.X - (racket.Width / 2);
            if (racket.Left < 0) { racket.Left = 0;  }
            if (racket.Left + racket.Width >= this.Width) { racket.Left = this.Width - racket.Width; }

            if( ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= racket.Left && ball.Right <= racket.Right)
            {
                ++speed_top;
                ++speed_left;
                speed_top = -speed_top;
                //speed_left = -speed_left;
                ++points;
                pts.Text = points.ToString();
                Console.Beep();

            }
            if( ball.Left <= playground.Left)
            {
                speed_left = -speed_left;

            }
            if(ball.Right >= playground.Right)
            {
                speed_left = -speed_left;
            }
            if(ball.Top <= playground.Top)
            { 
                speed_top = -speed_top; 
            }
            if(ball.Bottom >= playground.Bottom)
            {
                timer1.Enabled = false;
                this.Close();
                gameover.Visible = true;
            }
        }
    }
}
