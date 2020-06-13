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
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }
   

        private void formLogin_Load(object sender, EventArgs e)
        {
            classStaff stf = new classStaff();
            stf.staffGetInfo(cbUser);
            txtPassword.PasswordChar = '*';

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            classGeneral gnl = new classGeneral();

            classStaff stf = new classStaff();
            bool result = stf.staffLoginControl(txtPassword.Text, classGeneral._StaffId);
            if (result)
            {
                classStaffActions staffact = new classStaffActions();
                staffact.StaffId = classGeneral._StaffId;
                staffact.Process = "Logged in";
                staffact.Date = DateTime.Now;
                staffact.StaffSaveAction(staffact);
                this.Hide();
                formMenu menu = new formMenu();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Password is not correct!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void cbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            classStaff stf = (classStaff)cbUser.SelectedItem;
            classGeneral._StaffId = stf.StaffId;
            classGeneral._TaskId = stf.StaffTaskId;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
