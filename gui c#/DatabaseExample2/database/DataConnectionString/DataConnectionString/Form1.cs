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
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=I:\1Westchester Community College\GUI DEVELOPMENT\Programs\AccessDataBase\Contactmanager.accdb;
Persist Security Info=False;";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MessageBox.Show("Connection Successful","title",MessageBoxButtons.OK);
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("error "+ ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command =  new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from contacts where [Last Name] = '" + txt_lastname.Text + "' AND [First Name] = '" + txt_FirstName.Text + "';";
            OleDbDataReader reader = command.ExecuteReader();
         
           int count=0;
            while (reader.Read())
            {
                string jobTitle = reader.GetString(5);
                string homePhone = reader.GetString(6);
                txt_title.Text = jobTitle;
                txt_Phone.Text = homePhone;
                count = count+1;
            }
            if (count == 1 )
            {
                MessageBox.Show ("record found");
            }
            else 
            {
                MessageBox.Show ("miss");
            }
                

        }

    }
}
