//Avery Ali Calculator
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media; //added for beep sound
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        double calcResult = 0;
        String operation = "";
        bool operation_pressed = false;
        bool multioperand = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //ignore
        {
            result.Text = result.Text + button1.Text;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (multioperand)
            {
                multioperand = false;
                result.Text = "";
            }
            if (result.Text == "0")
            {
                result.Text = ""; //gets rid of starting 0
            }
                
            Button b = (Button)sender; //any button pressed is sent as an object stored in b, cast sender to button
            if ((b.Text == ".") & (result.Text.Contains(".")))
            {
                SystemSounds.Beep.Play(); 
            }
            else
            {
                result.Text = result.Text + b.Text;
            }
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            equation.Text = "";
            calcResult = 0;
            operation = "";
            operation_pressed = false;
        }
        private void buttonCe_Click(object sender, EventArgs e)
        {
            result.Text = "0"; //clear entry
            calcResult = 0;
            operation = "";
            operation_pressed = false;
        }

        private void oper_click(object sender, EventArgs e)
        {
            Button a = (Button)sender;
            
            if (calcResult != 0)
            {
                equation.Text = equation.Text + " " + result.Text + " " + a.Text;
                buttonEqual.PerformClick();
                calcResult = Double.Parse(result.Text);
                operation = a.Text;
                multioperand = true;
            }
            else
            {           
                equation.Text = equation.Text + " " + result.Text + " " + a.Text;
                operation = a.Text;  //get the operation from the button pressed
                calcResult = Double.Parse(result.Text); //change text to double
                result.Text = "0";
            }
       
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            double secondOperator;
            secondOperator = Double.Parse(result.Text);
            
            switch (operation)
            { 
                case "+":
                    result.Text = (calcResult + secondOperator).ToString();
                    break;
                
                case "-":
                    result.Text = (calcResult - secondOperator).ToString();
                    break;
                
                case "*":
                    result.Text = (calcResult * secondOperator).ToString();
                    break;
                
                case "/":
                    result.Text = (calcResult / secondOperator).ToString();
                    break;
                default:
                    break;
            }//end switch

        }

        private void form1_keyPressed(object sender, KeyPressEventArgs e)
        {
            String kp = e.KeyChar.ToString(); //capture key press
            switch (kp)
            {
                case "0":
                    {
                        //go somewhere else in your code, 
                        //button1.click = new EventHandler(ButtonClicked);
                        //button_click(button1,null); same thing as below...
                        button0.PerformClick(); //this is like they clicked the button 0
                        break;
                    }
                case "1": { button1.PerformClick(); break; }
                case "2": { button2.PerformClick(); break; }
                case "3": { button3.PerformClick(); break; }
                case "4": { button4.PerformClick(); break; }
                case "5": { button5.PerformClick(); break; }
                case "6": { button6.PerformClick(); break; }
                case "7": { button7.PerformClick(); break; }
                case "8": { button8.PerformClick(); break; }
                case "9": { button9.PerformClick(); break; }
                case "+": { buttonPlus.PerformClick(); break; }
                case "-": { buttonMinus.PerformClick(); break; }
                case "*": { buttonTimes.PerformClick(); break; }
                case "/": { buttonDivide.PerformClick(); break; }
                case "=": { buttonEqual.PerformClick(); break; }
                default:    break;              
            }//end switch

            
            
        }//end keypress f(x)

       
    }
}
