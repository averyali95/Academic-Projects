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
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;
Data Source=C:\Users\Avery\Desktop\school\wcc semester 4\gui\DatabaseExample2\data connect example\DataConnectionStringStart\DataConnectionString\Contactmanager.accdb;
Persist Security Info=False;";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            {
                WindowState = FormWindowState.Maximized;
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from contacts;";
                //command.CommandText = "select * from contacts where [Last Name] = '" + txt_lastname.Text + "' AND [First Name] = '" + txt_FirstName.Text + "';";
                OleDbDataReader reader = command.ExecuteReader();

                int count = 0;
                while (reader.Read())
                {

                    cmb_Names.Items.Add(reader[2].ToString() + ", " + reader[3].ToString()); //add items to the combo box
                    count = count + 1;
                }
            

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmb_Names.SelectedItem != null)
            {
                recordSelected.selid = cmb_Names.SelectedIndex.ToString();
                recordSelected.selname = cmb_Names.SelectedText;   //error........................................
                ShowDetailName showdetailname = new ShowDetailName(); //open up a new show detailformname
                showdetailname.Visible = true; //make the form visible (non visible by default
            }
            else
                MessageBox.Show("Please Select a Name", "Input Error");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
