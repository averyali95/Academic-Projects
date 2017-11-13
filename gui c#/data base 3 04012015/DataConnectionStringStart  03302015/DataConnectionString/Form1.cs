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

namespace DataConnectionString
{
    public partial class Form1 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Form1()
        {
            
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Avery\Desktop\school\wcc semester 4\gui\data base 3 04012015\DataConnectionStringStart  03302015\DataConnectionString\Contactmanager.accdb;
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
                command.CommandText = "select * from contacts;";
                //command.CommandText = "select * from contacts where [Last Name] = '" + txt_lastname.Text + "' AND [First Name] = '" + txt_FirstName.Text + "';";
                OleDbDataReader reader = command.ExecuteReader();

                int count = 0;
                while (reader.Read()) //fill in combobox
                {

                    cmb_Names.Items.Add(reader[2].ToString() + ", " + reader[3].ToString());

                    count = count + 1;
                }

            }
           catch (Exception ex)
           {
               MessageBox.Show("error " + ex);
           }
           connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
           
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from contacts;";
            //command.CommandText = "select * from contacts where [Last Name] = '" + txt_lastname.Text + "' AND [First Name] = '" + txt_FirstName.Text + "';";
            OleDbDataReader reader = command.ExecuteReader();
            cmb_Names.Items.Clear();
            int count = 0;
            while (reader.Read())
            {

                cmb_Names.Items.Add(reader[2].ToString() + ", " + reader[3].ToString());

                count = count + 1;
            }
            connection.Close();
        }

    }
}
