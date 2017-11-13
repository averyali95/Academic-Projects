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
    public partial class AddMessage : Form
    {
        private OleDbConnection connection = new OleDbConnection();

        public AddMessage()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Avery\Desktop\school\wcc semester 4\gui\data base 3 04012015\DataConnectionStringStart  03302015\DataConnectionString\Contactmanager.accdb;
Persist Security Info=False;";
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddMessage_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            this.Text = "Add Message for " + RecordSelected.selname;

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string updateCommand = "INSERT INTO Calls ( [Contact], [Call Time], [Subject], [Notes] ) Values ('" + RecordSelected.selid + "', '" + dateTimePicker.Value+ "', '" + cmb_service.Text + "', '" + addNotes.Text + "');";
                OleDbCommand command = new OleDbCommand(updateCommand, connection);
                command.ExecuteNonQuery();
                connection.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);
            }
        }
    }
}
