using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clickme
{
    public partial class Form1 : Form
    {
        //generate random number
        Random randomizer = new Random();
        int counter = 0;

        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_click_Click(object sender, EventArgs e)
        {
            int maxWidth = this.Width - btn_click.Width; //get width of screen and subtract width of button to keep btn on screen
            int maxHeight = this.Height - btn_click.Height;
            int newWidth = randomizer.Next(maxWidth);
            int newHeight = randomizer.Next(maxHeight);

            btn_click.Top = newHeight;
            btn_click.Left = newWidth;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.Width < btn_click.Left+btn_click.Width )
            {
                btn_click.Left = this.Width - btn_click.Width;
            }
            if (this.Height < btn_click.Top + btn_click.Height)
            {
                btn_click.Top = this.Height - btn_click.Height;
            }
            // btn_click.Top = 0; //if form is resized, put button in top left corner
            // btn_click.Left = 0;
            
        }
    }
}
