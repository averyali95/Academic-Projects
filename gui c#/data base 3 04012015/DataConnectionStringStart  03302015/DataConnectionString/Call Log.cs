using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataConnectionString
{
    public partial class Call_Log : Form
    {
        public Call_Log()
        {
            InitializeComponent();
        }

        private void Call_Log_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            this.Text = RecordSelected.selname;
        }
    }
}
