using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Rectangle goal = new Rectangle(350, 650, 50, 50);
        private Rectangle player = new Rectangle(350, 0, 50, 50);
        private Rectangle enemy1 = new Rectangle(0, 150, 75, 75);
        private Rectangle enemy2 = new Rectangle(675, 350, 75, 75);
        public Form1()
        {
            InitializeComponent();
            this.MaximumSize = new Size(750, 750);
            this.MinimumSize = new Size(750, 750);
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(myBrush, enemy1);
            myBrush.Dispose();

            System.Drawing.SolidBrush myBrush2 = new System.Drawing.SolidBrush(System.Drawing.Color.Orange);
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(myBrush2, enemy2);
            myBrush2.Dispose();

            System.Drawing.SolidBrush myBrush3 = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(myBrush3, player);
            myBrush3.Dispose();

            System.Drawing.SolidBrush myBrush4 = new System.Drawing.SolidBrush(System.Drawing.Color.Yellow);
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(myBrush4, goal);
            myBrush4.Dispose();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int playerx = player.Location.X;
            int playery = player.Location.Y;

            switch(e.KeyData)
            {
                case Keys.Up:
                    player.Location = new Point(playerx += 0,playery -= 20);
                    this.Refresh();
                    break;
                case Keys.Down:
                    player.Location = new Point(playerx += 0, playery += 20);
                    this.Refresh();
                    break;
                case Keys.Left:
                    player.Location = new Point(playerx -= 20, playery += 0);
                    this.Refresh();
                    break;
                case Keys.Right:
                    player.Location = new Point(playerx += 20, playery += 0);
                    this.Refresh();
                    break;

            }

            if(player.Location.X > 675)
            {
                player.Location = new Point(playerx += 20, playery += 0);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int ex1 = enemy1.Location.X;
            int ey1 = enemy1.Location.Y;
            int ex2 = enemy2.Location.X;
            int ey2 = enemy2.Location.Y;

            if(ex1 > 675)
            {
                enemy1.Location = new Point(ex1 = 0, ey1 = 150);
            }
            enemy1.Location = new Point(ex1 += 30, ey1 += 0);
            this.Refresh();

            if (ex2 < 0)
            {
                enemy2.Location = new Point(ex2 = 675, ey2 += 0);
            }
            enemy2.Location = new Point(ex2 -= 30, ey2 -= 0);
            this.Refresh();
        }
    }
}
