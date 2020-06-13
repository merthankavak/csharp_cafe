using ControlzEx.Standard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;


namespace cafe
{
    public partial class formTables : Form
    { 
        public formTables()
        {
            InitializeComponent();
        }
        classGeneral gnrl = new classGeneral();

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            formMenu frm = new formMenu();
            this.Close();
            frm.Show();
        }

       

        private void btnTable1_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable1.Text;
            classGeneral._ButtonName = btnTable1.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable2_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable2.Text;
            classGeneral._ButtonName = btnTable2.Name;
            this.Close();
            frm.ShowDialog();
        }

  

        private void btnTable3_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable3.Text;
            classGeneral._ButtonName = btnTable3.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable4_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable4.Text;
            classGeneral._ButtonName = btnTable4.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable5_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable5.Text;
            classGeneral._ButtonName = btnTable5.Name;
            this.Close();
            frm.ShowDialog();
        }


        private void btnTable6_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable6.Text;
            classGeneral._ButtonName = btnTable6.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable7_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable7.Text;
            classGeneral._ButtonName = btnTable7.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable8_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable8.Text;
            classGeneral._ButtonName = btnTable8.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable9_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable9.Text;
            classGeneral._ButtonName = btnTable9.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable10_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable10.Text;
            classGeneral._ButtonName = btnTable10.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable11_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable11.Text;
            classGeneral._ButtonName = btnTable11.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable12_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable12.Text;
            classGeneral._ButtonName = btnTable12.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable13_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable13.Text;
            classGeneral._ButtonName = btnTable13.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable14_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable14.Text;
            classGeneral._ButtonName = btnTable14.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable15_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable15.Text;
            classGeneral._ButtonName = btnTable15.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable16_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable16.Text;
            classGeneral._ButtonName = btnTable16.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable17_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable17.Text;
            classGeneral._ButtonName = btnTable17.Name;
            this.Close();
            frm.ShowDialog();

        }

        private void btnTable18_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable18.Text;
            classGeneral._ButtonName = btnTable18.Name;
            this.Close();
            frm.ShowDialog();

        }

        private void btnTable19_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable19.Text;
            classGeneral._ButtonName = btnTable19.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable20_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable20.Text;
            classGeneral._ButtonName = btnTable20.Name;
            this.Close();
            frm.ShowDialog();

        }

        private void btnTable21_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable21.Text;
            classGeneral._ButtonName = btnTable21.Name;
            this.Close();
            frm.ShowDialog();

        }

        private void btnTable22_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable22.Text;
            classGeneral._ButtonName = btnTable22.Name;
            this.Close();
            frm.ShowDialog();

        }

        private void btnTable23_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable23.Text;
            classGeneral._ButtonName = btnTable23.Name;
            this.Close();
            frm.ShowDialog();

        }

        private void btnTable24_Click(object sender, EventArgs e)
        {
            formOrder frm = new formOrder();
            classGeneral._ButtonValue = btnTable24.Text;
            classGeneral._ButtonName = btnTable24.Name;
            this.Close();
            frm.ShowDialog();

        }



        private void formTables_Load(object sender, EventArgs e)
        {
            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("SELECT status,id FROM tables", connec);
            SqlDataReader dr = null;
            if (connec.State == ConnectionState.Closed)
            {
                connec.Open();
            }
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                foreach (Control item in this.Controls)
                {
                    if (item is Button)
                    {
                        if (item.Name == "btnTable" + dr["id"].ToString() && dr["status"].ToString() == "1")
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.table_empty);
                        }
                        else if (item.Name == "btnTable" + dr["id"].ToString() && dr["status"].ToString() == "2")
                        {
                            classTables tb = new classTables();

                            DateTime dt1 = Convert.ToDateTime(tb.SessionSum(2, dr["id"].ToString()));
                            DateTime dt2 = DateTime.Now;

                            string str1 = Convert.ToDateTime(tb.SessionSum(2, dr["id"].ToString())).ToShortTimeString();
                            string str2 = DateTime.Now.ToShortTimeString();

                            DateTime t1 = dt1.AddMinutes(DateTime.Parse(str1).TimeOfDay.TotalMinutes);
                            DateTime t2 = dt2.AddMinutes(DateTime.Parse(str2).TimeOfDay.TotalMinutes);

                            var diff = t2 - t1;

                            item.Text = String.Format("{0} {1} {2}",
                            diff.Days > 0 ? String.Format("{0} Day", diff.Days) : "",
                            diff.Hours > 0 ? String.Format("{0} Hours", diff.Hours) : "",
                            diff.Minutes > 0 ? String.Format("{0} Minute", diff.Minutes) : "").Trim() + "\n\n\n\nTable " + dr["id"].ToString();
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.table_full);
                        }
                        else if (item.Name == "btnTable" + dr["id"].ToString() && dr["status"].ToString() == "3")
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.table_openreserve);
                        }
                        else if (item.Name == "btnTable" + dr["id"].ToString() && dr["status"].ToString() == "4")
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.table_reserved);
                        }
                    }
                }

            }



        }
    }
}
