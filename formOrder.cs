using System;
using System.Collections;
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
    public partial class formOrder : Form
    {
        public formOrder()
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

        private void btnBack_Click(object sender, EventArgs e)
        {

            formMenu frm = new formMenu();
            this.Close();
            frm.Show();
        }

        void operations(Object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name)
            {
                case "btn1":
                    txtQuantity.Text += (1).ToString();
                    break;
                case "btn2":
                    txtQuantity.Text += (2).ToString();
                    break;
                case "btn3":
                    txtQuantity.Text += (3).ToString();
                    break;
                case "btn4":
                    txtQuantity.Text += (4).ToString();
                    break;
                case "btn5":
                    txtQuantity.Text += (5).ToString();
                    break;
                case "btn6":
                    txtQuantity.Text += (6).ToString();
                    break;
                case "btn7":
                    txtQuantity.Text += (7).ToString();
                    break;
                case "btn8":
                    txtQuantity.Text += (8).ToString();
                    break;
                case "btn9":
                    txtQuantity.Text += (9).ToString();
                    break;
                case "btn0":
                    txtQuantity.Text += (0).ToString();
                    break;

                default:
                    MessageBox.Show("Enter Quantity of Product!");
                    break;
            }

        }
        int tableId,AdditionId;
        private void formOrder_Load(object sender, EventArgs e)
        {
            labelTableNo.Text = classGeneral._ButtonValue;
            classTables tn = new classTables();
            tableId = tn.TableGetbyNumber(classGeneral._ButtonName);
            if (tn.TableGetbyState(tableId, 2)==true || tn.TableGetbyState(tableId, 4)==true)
            {
                classAdditions adis = new classAdditions();
                AdditionId = adis.getByAddition(tableId);
                classSales sales = new classSales();
                sales.getByOrder(lvSales, AdditionId);
            }

            btn1.Click += new EventHandler(operations);
            btn2.Click += new EventHandler(operations);
            btn3.Click += new EventHandler(operations);
            btn4.Click += new EventHandler(operations);
            btn5.Click += new EventHandler(operations);
            btn6.Click += new EventHandler(operations);
            btn7.Click += new EventHandler(operations);
            btn8.Click += new EventHandler(operations);
            btn9.Click += new EventHandler(operations);
            btn0.Click += new EventHandler(operations);

        }

        private void btnBreakfast1_Click(object sender, EventArgs e)
        {
            classProductType pt = new classProductType();
            pt.getByProductTypes(lvMenu, btnBreakfast1);
        }

        private void btnFastFood2_Click(object sender, EventArgs e)
        {
            classProductType pt = new classProductType();
            pt.getByProductTypes(lvMenu, btnFastFood2);
        }

        private void btnPastaandSalad3_Click(object sender, EventArgs e)
        {
            classProductType pt = new classProductType();
            pt.getByProductTypes(lvMenu, btnPastaandSalad3);
        }

        private void BtnSpecialties4_Click(object sender, EventArgs e)
        {
            classProductType pt = new classProductType();
            pt.getByProductTypes(lvMenu, BtnSpecialties4);
        }
       
        private void BtnColdDrinks5_Click(object sender, EventArgs e)
        {
            classProductType pt = new classProductType();
            pt.getByProductTypes(lvMenu, BtnColdDrinks5);
        }


        private void BtnCoffee6_Click(object sender, EventArgs e)
        {
            classProductType pt = new classProductType();
            pt.getByProductTypes(lvMenu, BtnCoffee6);
        }

       
        private void BtnHotDrinks7_Click(object sender, EventArgs e)
        {
            classProductType pt = new classProductType();
            pt.getByProductTypes(lvMenu, BtnHotDrinks7);
        }

        private void btnDesserts8_Click(object sender, EventArgs e)
        {
            classProductType pt = new classProductType();
            pt.getByProductTypes(lvMenu, btnDesserts8);
        }
        int count1 = 0, count2 = 0;

        ArrayList deleted = new ArrayList();

        private void btnOrder_Click(object sender, EventArgs e)
        {
            /*
                1-Table Empty
                2-Table Full
                3-Table Reserved
                4-Full
            */

            classTables tbl = new classTables();
            classAdditions newAddition = new classAdditions();
            classSales saveOrder = new classSales();
            formTables tbf = new formTables();

            bool result = false;
            if (tbl.TableGetbyState(tableId,1)==true)
            {
                newAddition.ServiceType_Id = 1;
                newAddition.Staff_Id = 1;
                newAddition.Table_Id = tableId;
                newAddition.Date = DateTime.Now;
                result = newAddition.setByAdditionNew(newAddition);
                tbl.setChangeTableState(classGeneral._ButtonName, 2);

                if (lvSales.Items.Count>0)
                {
                    for (int i = 0; i < lvSales.Items.Count; i++)
                    {
                        saveOrder.Table_Id = tableId;
                        saveOrder.Product_Id=Convert.ToInt32(lvSales.Items[i].SubItems[2].Text);
                        saveOrder.Addition_Id = newAddition.getByAddition(tableId);
                        saveOrder.Quantity = Convert.ToInt32(lvSales.Items[i].SubItems[1].Text);
                        saveOrder.setSaveOrder(saveOrder);

                    }
                    
                    this.Close();
                    tbf.Show();
                }
            }
            else if (tbl.TableGetbyState(tableId, 2) == true || tbl.TableGetbyState(tableId,4)==true)
            {
    
                if (lvNewAdded.Items.Count > 0)
                {
                    for (int i = 0; i < lvNewAdded.Items.Count; i++)
                    {
                        saveOrder.Table_Id = tableId;
                        saveOrder.Product_Id = Convert.ToInt32(lvNewAdded.Items[i].SubItems[1].Text);
                        saveOrder.Addition_Id = newAddition.getByAddition(tableId);
                        saveOrder.Quantity = Convert.ToInt32(lvNewAdded.Items[i].SubItems[2].Text);
                        saveOrder.setSaveOrder(saveOrder);
                    }
                }
                if (deleted.Count>0)
                {
                    foreach (string item  in deleted)
                    {
                        saveOrder.setDeleteOrder(Convert.ToInt32(item));
                    }
                }
                this.Close();
                tbf.Show();
            }
            else if (tbl.TableGetbyState(tableId, 3) == true)
            {
  
                newAddition.ServiceType_Id = 1;
                newAddition.Staff_Id = 1;
                newAddition.Table_Id = tableId;
                newAddition.Date = DateTime.Now;
                result = newAddition.setByAdditionNew(newAddition);
                tbl.setChangeTableState(classGeneral._ButtonName, 4);

                if (lvSales.Items.Count > 0)
                {
                    for (int i = 0; i < lvSales.Items.Count; i++)
                    {
                        saveOrder.Table_Id = tableId;
                        saveOrder.Product_Id = Convert.ToInt32(lvSales.Items[i].SubItems[2].Text);
                        saveOrder.Addition_Id = newAddition.getByAddition(tableId);
                        saveOrder.Quantity = Convert.ToInt32(lvSales.Items[i].SubItems[1].Text);
                        saveOrder.setSaveOrder(saveOrder);

                    }

                    this.Close();
                    tbf.Show();
                }
            }

        }

        private void lvMenu_DoubleClick(object sender, EventArgs e)
        {
            if (txtQuantity.Text=="")
            {
                txtQuantity.Text = "1";
            }

            if (lvMenu.Items.Count > 0)
            {
                count1 = lvSales.Items.Count;
                lvSales.Items.Add(lvMenu.SelectedItems[0].Text);
                lvSales.Items[count1].SubItems.Add(txtQuantity.Text);
                lvSales.Items[count1].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvSales.Items[count1].SubItems.Add((Convert.ToDecimal(lvMenu.SelectedItems[0].SubItems[1].Text) * Convert.ToDecimal(txtQuantity.Text)).ToString());
                lvSales.Items[count1].SubItems.Add("0");
                count2 = lvNewAdded.Items.Count;
                lvSales.Items[count1].SubItems.Add(count2.ToString());
                lvNewAdded.Items.Add(AdditionId.ToString());
                lvNewAdded.Items[count2].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvNewAdded.Items[count2].SubItems.Add(txtQuantity.Text);
                lvNewAdded.Items[count2].SubItems.Add(tableId.ToString());
                lvNewAdded.Items[count2].SubItems.Add(count2.ToString());
                count2++;
                txtQuantity.Text = "";


            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {

            classGeneral._ServiceTypeNo = 1;
            classGeneral._AdditionId = AdditionId.ToString();
            formBill frm = new formBill();
            this.Close();
            frm.Show();
        }

        private void lvSales_DoubleClick(object sender, EventArgs e)
        {
            if (lvSales.Items.Count > 0)
            {
                if (lvSales.SelectedItems[0].SubItems[1].Text != "0")
                {
                    classSales saveOrder = new classSales();
                    saveOrder.setDeleteOrder(Convert.ToInt32(lvSales.SelectedItems[0].SubItems[4].Text));

                }
                else
                {
                    for (int i = 0; i < lvNewAdded.Items.Count; i++)
                    {
                        if (lvNewAdded.Items[i].SubItems[4].Text == lvSales.SelectedItems[0].SubItems[0].Text)
                        {
                            lvNewAdded.Items.RemoveAt(i);
                        }
                    }
                }

                lvSales.Items.RemoveAt(lvSales.SelectedItems[0].Index);
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text=="")
            {
                txtSearch.Text = "";
            }
            else
            {
                classProductType pt = new classProductType();
                pt.getByProductSearch(lvMenu, Convert.ToInt32(txtSearch.Text));
            }

        }

    }
}
