using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace cafe
{
    public partial class AddCustormers : Form
    {
        public AddCustormers()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                this.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
            formCustomersSearch frm = new formCustomersSearch();
            frm.Show();

        }

        private void btnAddCustomers_Click(object sender, EventArgs e)
        {
            if (txtCustomerPhone.Text.Length > 6)
            {
                if (txtCustomerName.Text == "" || txtCustomerSurname.Text == "")
                {
                    MessageBox.Show("Please Enter Name and Surname.");
                }
                else
                {
                    classCustomers c = new classCustomers();
               
               
                    bool result = c.CheckCustomer(txtCustomerPhone.Text);
                    if (!result || classGeneral._customerId > 0)
                    {
                        c.CustomerName = txtCustomerName.Text;
                        c.CustomerSurname = txtCustomerSurname.Text;
                        c.Phone = txtCustomerPhone.Text;
                        c.Mail = txtCustomerEmail.Text;
                        c.Adress = txtCustomerAdress.Text;
                        txtCustomerId.Text = c.AddCustomer(c).ToString();
                        txtCustomerId.Text = classGeneral._customerId.ToString();
                        c.getCustomerID(Convert.ToInt32(txtCustomerId.Text), txtCustomerName, txtCustomerSurname, txtCustomerPhone, txtCustomerAdress, txtCustomerEmail);
                        if (txtCustomerId.Text != "")
                        {
                            MessageBox.Show("Successfully Added.");
                        }
                        else
                        {
                            MessageBox.Show("Error! Customer could not be added.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("This customer already exists.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Enter Minimum 7 Number.");
            }
        }

        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            if (classGeneral._AddCustomer == 0) 
            {
                formReservations frm = new formReservations();
                classGeneral._AddCustomer = 1;
                this.Close();
                frm.Show();
            }
            else if (classGeneral._AddCustomer == 1)
            {
                formPackageOrder frm = new formPackageOrder();
                classGeneral._AddCustomer = 0;
                this.Close();
                frm.Show();
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (txtCustomerPhone.Text.Length > 6)
            {
                if (txtCustomerName.Text == "" || txtCustomerSurname.Text == "")
                {
                    MessageBox.Show("Please Enter Name and Surname.");
                }
                else
                {
                    classCustomers c = new classCustomers();

                    c.CustomerName = txtCustomerName.Text;
                    c.CustomerSurname = txtCustomerSurname.Text;
                    c.Phone = txtCustomerPhone.Text;
                    c.Adress = txtCustomerAdress.Text;
                    c.Mail = txtCustomerEmail.Text;
                    c.CustomerId = Convert.ToInt32(txtCustomerId.Text);
                    bool result = c.UpdateCustomer(c);
                
                    if (!result)
                    {
                       
                        if (txtCustomerId.Text != "")
                        {
                            MessageBox.Show("Successfully Updated.");
                        }
                        else
                        {
                            MessageBox.Show("Error! Customer could not be updated.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Successfully Updated..");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Enter Minimum 7 Number.");
            }
        }

        private void AddCustormers_Load(object sender, EventArgs e)
        {
           
          
            if (classGeneral._customerId>0 )
            {
                classCustomers c = new classCustomers();
                txtCustomerId.Text = classGeneral._customerId.ToString();
                c.getCustomerID(Convert.ToInt32(txtCustomerId.Text), txtCustomerName, txtCustomerSurname, txtCustomerPhone, txtCustomerAdress, txtCustomerEmail);
                
            
            }
        }

        
    }
}
