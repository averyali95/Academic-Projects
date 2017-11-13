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
    public partial class ShowDetailName : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        private OleDbConnection connection2 = new OleDbConnection();

        public ShowDetailName()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Avery\Desktop\school\wcc semester 4\gui\final database question\Student.mdb;
            Persist Security Info=False;";
            connection2.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Avery\Desktop\school\wcc semester 4\gui\final database question\Student.mdb;
            Persist Security Info=False;";
        }

        private void ShowDetailName_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            this.Text = RecordSelected.selname + " Student Information";
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string wkname = RecordSelected.selname;
                string lastname = wkname.Split(',')[0];
                string firstname = wkname.Split(',')[1].Trim();
                command.CommandText = "select * from Students where [Last Name] = '" + lastname + "' AND [First Name] = '" + firstname + "';";
                //command.CommandText = "select * from contacts where [Last Name] = '" + txt_lastname.Text + "' AND [First Name] = '" + txt_FirstName.Text + "';";
                OleDbDataReader reader = command.ExecuteReader();

                reader.Read();
                RecordSelected.selid = reader["Student ID"].ToString();
                txt_Name.Text = reader["First Name"].ToString();
                txt_LastName.Text = reader["Last Name"].ToString();
                txt_Gender.Text = reader["Gender"].ToString();
                txt_Major.Text = reader["Major"].ToString();
                txt_Id.Text = RecordSelected.selid;
                connection.Close();
            }
            catch (Exception ex)
            {
               MessageBox.Show("error " + ex);
            }

            try 
            {
                //Load up Data Grid
                connection2.Open();
                //OleDbCommand command2 = new OleDbCommand()
                //command2.Connection = connection;
                string sql = "Select [STUDENT ID],[COURSE],[SECTION],[GRADE] from Classes where [Student ID] = " + RecordSelected.selid.ToString() + ";";
                //OleDbConnection connection2 = new OleDbConnection(ConnectionString);
                OleDbConnection connectionc = new OleDbConnection(connection2.ConnectionString);
                OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql, connection2);
                DataSet ds = new DataSet();
                //connectionc.Open();
                dataadapter.Fill(ds, "Classes");
                connectionc.Close();
                dataGridViewClasses.DataSource = ds;
                dataGridViewClasses.DataMember = "Classes";
                connection2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);
            }



        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
