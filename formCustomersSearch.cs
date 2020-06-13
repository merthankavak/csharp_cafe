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
    public partial class formCustomersSearch : Form
    {
        public formCustomersSearch()
        {
            InitializeComponent();
        }

     

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }



        private void btnGeri_Click(object sender, EventArgs e)
        {
            formMenu frm = new formMenu();
            this.Close();
            frm.Show();
        }

        private void btnAddCustomers_Click(object sender, EventArgs e)
        {
            AddCustormers frm = new AddCustormers();
            classGeneral._AddCustomer = 1;
            frm.Show();
        }

        private void formCustomers_Load(object sender, EventArgs e)
        {
            classCustomers c =new classCustomers();
            c.getCustomer(lvCustomers);
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
           
            if (lvCustomers.SelectedItems.Count>0)
            {
                AddCustormers frm = new AddCustormers();
                classGeneral._AddCustomer = 1;
                classGeneral._customerId = Convert.ToInt32(lvCustomers.SelectedItems[0].SubItems[0].Text);
                this.Close();
                frm.Show();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            classCustomers c = new classCustomers();
            c.getCustomerInformationbyFromName(lvCustomers, txtName.Text);
        }

        private void frmAdditions_Click(object sender, EventArgs e)
        {
            if (txtAdditionId.Text!="")
            {
                classGeneral._AdditionId = txtAdditionId.Text;
                classPackets c = new classPackets();
                bool result = c.getCheckOpenAdditionId(Convert.ToInt32(txtAdditionId.Text));
                if (result)
                {
                    formBill frm = new formBill();
                    classGeneral._ServiceTypeNo = 2;
                    frm.Show();
                }
                else
                {
                    MessageBox.Show(txtAdditionId.Text+". addition not found.","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                }

            }
            else
            {
                MessageBox.Show("Write the addition you want to search.", "Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
