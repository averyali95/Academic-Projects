using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace math
{
    public partial class Form1 : Form
    {
        //create a Random object called randomizer to generate random numbers
        Random randomizer = new Random();
        
        //create integers to store numbers for addition problems
        int addend1;
        int addend2;

        //add timer
        int timeLeft;


        public void StartTheQuiz()
        { 
            //fill in the addition problem
            //generate two random numbers to add store them in variables
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            //Convert the two randomly generated numbers into strings so they can be
            //displayed in the label
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // sum is the name of the numericupdown control, this makes sure its value is
            //zero before adding anyvalues to it
            sum.Value = 0;
            
            //start the timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
            
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //start the quiz 
            startButton.Enabled = false;
            startButton.Text = "disabled";
            StartTheQuiz();
              
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            //display time left
            
            if (CheckTheAnswer() == true)
            {
                timer1.Stop();
                MessageBox.Show("Thats correct!");
                startButton.Enabled = true;
                startButton.Text = "Start the quiz";
                timeLabel.Text = "30 seconds";
            }
            else if(timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up";
                MessageBox.Show("You didn't finish on time!");
                sum.Value = addend1 + addend2;
                startButton.Enabled = true;
                startButton.Text = "Start the quiz";
            }
        }

        private bool CheckTheAnswer()
        {
            if (addend1 + addend2 == sum.Value)
                return true;
            else
                return false;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}
