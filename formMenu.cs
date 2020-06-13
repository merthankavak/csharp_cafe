using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafe
{
    public partial class formMenu : Form
    {
        public formMenu()
        {
            InitializeComponent();
        }

        private void btnTableOrder_Click(object sender, EventArgs e)
        {
            formTables frm = new formTables();
            this.Close();
            frm.Show();
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            formReservations frm = new formReservations();
            this.Close();
            frm.Show();
        }

     

        private void btnCashier_Click(object sender, EventArgs e)
        {
            formCashier frm = new formCashier();
            this.Close();
            frm.Show();
        }

        private void btnKitchen_Click(object sender, EventArgs e)
        {
            formKitchen frm = new formKitchen();
            this.Close();
            frm.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            formReports frm = new formReports();
            this.Close();
            frm.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            formSettings frm = new formSettings();
            this.Close();
            frm.Show();
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            formLock frm = new formLock();
            this.Close();
            frm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            formCustomersSearch frm = new formCustomersSearch();
            this.Close();
            frm.Show();
        }
    }
}
