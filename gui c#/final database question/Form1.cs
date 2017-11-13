using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace final_database_question
{
    public partial class Form1 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Form1()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Avery\Desktop\school\wcc semester 4\gui\final database question\Student.mdb;
            Persist Security Info=False;";
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try 
            {
                WindowState = FormWindowState.Maximized;
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from Students";
                OleDbDataReader reader = command.ExecuteReader();

                int count = 0;
                while (reader.Read()) //fill in combobox
                {

                    cmb_Names.Items.Add(reader[1].ToString() + ", " + reader[2].ToString());

                    count = count + 1;
                }
                
            }
            catch{  MessageBox.Show("Couldnt connect");   }
            connection.Close();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            if (cmb_Names.SelectedItem != null) //after combobox item is selected 
            {
                RecordSelected.selid = cmb_Names.SelectedIndex.ToString();
                RecordSelected.selname = cmb_Names.Text.ToString();

                ShowDetailName showdetailname = new ShowDetailName();
                showdetailname.Visible = true;
            }
            else
            {
                MessageBox.Show("Please Select Name", "Input Error");
            }
        }
    }
}
