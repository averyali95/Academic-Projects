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
    public partial class ShowDetailName : Form
    {
        private OleDbConnection connection = new OleDbConnection();


        public ShowDetailName()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;
Data Source=C:\Users\Avery\Desktop\school\wcc semester 4\gui\DatabaseExample2\data connect example\DataConnectionStringStart\DataConnectionString\Contactmanager.accdb;
Persist Security Info=False;";
        }

        private void ShowDetailName_Load(object sender, EventArgs e)
        {
            this.Text = recordSelected.selname.ToString();
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            //command.CommandText = "select * from contacts;";
            string wkname = recordSelected.selname;
            string lastname = wkname.Split(',')[0];
            string firstname = wkname.Split(',')[1];
            command.CommandText = "select * from contacts where [Last Name] = '" + lastname + "' AND [First Name] = '" + firstname + "';";
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();
            txtFirstName.Text = reader["First Name"].ToString();
        }
    }
}
