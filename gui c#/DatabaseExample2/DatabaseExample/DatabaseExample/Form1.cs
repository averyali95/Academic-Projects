using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void contactsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.contactsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.contactmanagerDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'contactmanagerDataSet.Contacts' table. You can move, or remove it, as needed.
            this.contactsTableAdapter.Fill(this.contactmanagerDataSet.Contacts);
            WindowState = FormWindowState.Maximized;

        }

        private void btn_OpenName_Click(object sender, EventArgs e)
        {
            NameAddress nameaddress = new NameAddress();
            nameaddress.Visible = true;
        }

        private void contactsDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowenter = e.RowIndex;
            DataGridViewRow row = contactsDataGridView.Rows[rowenter];
            RecordSelected.selid = row.Cells[0].Value.ToString();
        }
    }
}
