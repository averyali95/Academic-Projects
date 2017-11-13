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

    //when updating a data and time you need #." [UpdateDate] = #'+datetime+' "
{
    public partial class ShowDetailName : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        private OleDbConnection connection2 = new OleDbConnection();
        public ShowDetailName()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Avery\Desktop\school\wcc semester 4\gui\data base 3 04012015\DataConnectionStringStart  03302015\DataConnectionString\Contactmanager.accdb;
Persist Security Info=False;";
            connection2.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Avery\Desktop\school\wcc semester 4\gui\data base 3 04012015\DataConnectionStringStart  03302015\DataConnectionString\Contactmanager.accdb;
Persist Security Info=False;";

        }

        private void ShowDetailName_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            this.Text = RecordSelected.selname + "Contact Information";
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            //command.CommandText = "select * from contacts;";
            string wkname = RecordSelected.selname;
            string lastname = wkname.Split(',')[0];
            string firstname = wkname.Split(',')[1].Trim();
            command.CommandText = "select * from contacts where [Last Name] = '" + lastname + "' AND [First Name] = '" + firstname + "';";
            //command.CommandText = "select * from contacts where [Last Name] = '" + txt_lastname.Text + "' AND [First Name] = '" + txt_FirstName.Text + "';";
            OleDbDataReader reader = command.ExecuteReader();

            reader.Read();
            RecordSelected.selid = reader["ID"].ToString();
            txtFirstname.Text = reader["First Name"].ToString();
            txtLastName.Text = reader["Last Name"].ToString();
            txtEmail.Text = reader["E-mail Address"].ToString();
            txtPhoneNumber.Text = reader["Business Phone"].ToString();
            txtJobTitle.Text = reader["Job Title"].ToString();
            connection.Close();

            try
            {
            //Load up Data Grid
            connection2.Open();
            //OleDbCommand command2 = new OleDbCommand()
            //command2.Connection = connection;
            string sql = "Select [CALL TIME],[SUBJECT],[NOTES] from calls where [Contact] = " + RecordSelected.selid.ToString() + ";";
            //OleDbConnection connection2 = new OleDbConnection(ConnectionString);
            OleDbConnection connectionc = new OleDbConnection(connection2.ConnectionString);
            OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql, connection2);
            DataSet ds = new DataSet();
            //connectionc.Open();
            dataadapter.Fill(ds, "Calls");
            connectionc.Close();
            dataGridViewCalls.DataSource = ds;
            dataGridViewCalls.DataMember = "Calls";
            connection2.Close();
             }
           catch (Exception ex)
           {
               MessageBox.Show("error " + ex);
           }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            connection.Open();
            string updateCommand = "UPDATE Contacts SET [Last Name] = '" + txtLastName.Text + "' , [First Name] = '" + txtFirstname.Text + "', [E-mail Address] = '" + txtEmail.Text + "' , [Job Title] = '" + txtJobTitle.Text + "', [Business Phone] = '" + txtPhoneNumber.Text + "' where [ID] = " + RecordSelected.selid + ";";
            OleDbCommand command = new OleDbCommand(updateCommand, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (btnInsert.Text == "Insert New Contact")
            {
                btnInsert.Text = "Add Record";
                txtFirstname.Text = "";
                txtLastName.Text = "";
                txtEmail.Text = "";
                txtPhoneNumber.Text = "";
                txtJobTitle.Text = "";
                txtFirstname.Focus();
            }
            else
            {
               
                connection.Open();
                string insertcommand = "INSERT INTO Contacts ( [Last Name], [First Name], [E-mail Address], [Job Title], [Business Phone]) Values ('" + txtFirstname.Text + "', '" + txtLastName.Text + "', '" + txtEmail.Text + "', '" + txtJobTitle.Text + "', '" + txtPhoneNumber.Text + "');";
                OleDbCommand command = new OleDbCommand(insertcommand, connection);
                command.ExecuteNonQuery();
                connection.Close();
                btnInsert.Text = "Insert New Contact";
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Message_Click(object sender, EventArgs e)
        {
            AddMessage message = new AddMessage();
            message.Visible = true;
        }
    }
}
