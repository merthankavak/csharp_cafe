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
    public partial class formBill : Form
    {
        public formBill()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            formMenu frm = new formMenu();
            this.Close();
            frm.Show();

           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        
        classSales cs = new classSales();
        int paymentmethodId = 0;

        private void formBill_Load(object sender, EventArgs e)
        {
            gbDiscount.Visible = false;
            if (classGeneral._ServiceTypeNo == 1) 
            {
                lbAdditionId.Text = classGeneral._AdditionId;
                txtDiscountAmount.TextChanged += new EventHandler(txtDiscountAmount_TextChanged);
                cs.getByOrder(lvProducts, Convert.ToInt32(lbAdditionId.Text));
                if (lvProducts.Items.Count > 0) 
                {
                    decimal tot = 0;
                    for (int i = 0; i < lvProducts.Items.Count; i++)
                    {

                        tot += Convert.ToDecimal(lvProducts.Items[i].SubItems[3].Text);
                    }
                    lbTotal.Text = string.Format("{0:0.00}", tot);
                    lbPayable.Text= string.Format("{0:0.00}", tot);
                    decimal tax = Convert.ToDecimal(lbPayable.Text) * 18 / 100;
                    lbTax.Text = string.Format("{0:0.00}", tax);

                }
                gbDiscount.Visible = true;
                txtDiscountAmount.Clear();
            }
            else if (classGeneral._ServiceTypeNo == 2)
            {
                lbAdditionId.Text = classGeneral._AdditionId;
                classPackets pc = new classPackets();
                paymentmethodId = pc.getPaymentMethodId(Convert.ToInt32(lbAdditionId.Text));


                txtDiscountAmount.TextChanged += new EventHandler(txtDiscountAmount_TextChanged);
                cs.getByOrder(lvProducts, Convert.ToInt32(lbAdditionId.Text));
                if (paymentmethodId==1)
                {
                    rbCash.Checked = true;
                }
                else if (paymentmethodId == 2)
                {
                    rbCreditCard.Checked = true;
                }
                else if (paymentmethodId == 3)
                {
                    rbTicket.Checked = true;
                }





                if (lvProducts.Items.Count > 0)
                {
                    decimal tot = 0;
                    for (int i = 0; i < lvProducts.Items.Count; i++)
                    {

                        tot += Convert.ToDecimal(lvProducts.Items[i].SubItems[3].Text);
                    }
                    lbTotal.Text = string.Format("{0:0.00}", tot);
                    lbPayable.Text = string.Format("{0:0.00}", tot);
                    decimal tax = Convert.ToDecimal(lbPayable.Text) * 18 / 100;
                    lbTax.Text = string.Format("{0:0.00}", tax);

                }
                gbDiscount.Visible = true;
                txtDiscountAmount.Clear();
            }
        }

        private void txtDiscountAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtDiscountAmount.Text)<Convert.ToDecimal(lbTotal.Text))
                {
                    try
                    {
                        lbDiscount.Text= string.Format("{0:0.00}", Convert.ToDecimal(txtDiscountAmount.Text));
                    }
                    catch (Exception)
                    {

                        lbDiscount.Text = string.Format("{0:0.00}", 0);
                    }
                }
                else
                {
                    MessageBox.Show("The discount amount cannot exceed the total amount!");
                }
            }
            catch (Exception)
            {

                lbDiscount.Text = string.Format("{0:0.00}", 0);
            }
        }

        private void chkDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiscount.Checked)
            {
                gbDiscount.Visible = true;
                txtDiscountAmount.Clear();
            }
            else
            {
                gbDiscount.Visible = false;
                txtDiscountAmount.Clear();
            }
        }

        private void lbDiscount_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lbDiscount.Text)>0)
            {
                decimal payable = 0;
                lbPayable.Text = lbTotal.Text;
                payable = Convert.ToDecimal(lbPayable.Text) - Convert.ToDecimal(lbDiscount.Text);
                lbPayable.Text = string.Format("{0:0.00}", payable);
            }

            decimal tax = Convert.ToDecimal(lbPayable.Text)*18/100;
            lbTax.Text= string.Format("{0:0.00}", tax);
        }

        classTables tb = new classTables();
        classReservation reserve = new classReservation();
        private void btnPayOff_Click(object sender, EventArgs e)
        {
            if (classGeneral._ServiceTypeNo==1)
            {
                int tableid = tb.TableGetbyNumber(classGeneral._ButtonName);
                int customerId = 0;
                if (tb.TableGetbyState(tableid,4)==true)
                {
                    customerId = reserve.getCustomerIdFromReservations(tableid);
                }
                else
                {
                    customerId = 1;
                }
                int paymentmethodId = 0;
                if (rbCreditCard.Checked)
                {
                    paymentmethodId = 2;
                }
                if (rbCash.Checked)
                {
                    paymentmethodId = 1;
                }
                if (rbTicket.Checked)
                {
                    paymentmethodId = 3;
                }

                classPayment pay = new classPayment();
                //addition_id,paymentmethod_id,customer_id,subtotal,tax,discount,total
                pay.Addition_Id= Convert.ToInt32(lbAdditionId.Text);
                pay.PaymentMethod_Id = paymentmethodId;
                pay.Customer_Id = customerId;
                pay.Subtotal = Convert.ToDecimal(lbPayable.Text);
                pay.Tax= Convert.ToDecimal(lbTax.Text);
                pay.Total = Convert.ToDecimal(lbTotal.Text);
                pay.Discount = Convert.ToDecimal(lbDiscount.Text);

                bool result = pay.billClose(pay);
                if (result)
                {
                    MessageBox.Show("Successfully Closed.");
                    tb.setChangeTableState(Convert.ToString(tableid), 1);
                    classReservation c = new classReservation();
                    c.reservationClose(Convert.ToInt32(lbAdditionId.Text));
                    classAdditions a = new classAdditions();
                    a.additionClose(Convert.ToInt32(lbAdditionId.Text), 0);

                    this.Close();
                    formTables frm = new formTables();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Not Closed ! Please report the authority.");
                }


            }
            //PACKAGE ORDER
            else if (classGeneral._ServiceTypeNo == 2)
            {

                classPayment pay = new classPayment();
                //addition_id,paymentmethod_id,customer_id,subtotal,tax,discount,total
                pay.Addition_Id = Convert.ToInt32(lbAdditionId.Text);
                pay.PaymentMethod_Id = paymentmethodId;
                pay.Customer_Id = 1;
                pay.Subtotal = Convert.ToDecimal(lbPayable.Text);
                pay.Tax = Convert.ToDecimal(lbTax.Text);
                pay.Total = Convert.ToDecimal(lbTotal.Text);
                pay.Discount = Convert.ToDecimal(lbDiscount.Text);
                bool result = pay.billClose(pay);
                if (result)
                {
                    MessageBox.Show("Successfully Closed.");
                    classAdditions a = new classAdditions();
                    a.additionClose(Convert.ToInt32(lbAdditionId.Text), 0);

                    classPackets p = new classPackets();
                    p.packageOrderClose(Convert.ToInt32(lbAdditionId.Text));
                  

                    this.Close();
                    formTables frm = new formTables();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Not Closed ! Please report the authority.");
                }


            }




        }

        private void btnStatement_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
        Font Title = new Font("Verdana", 15, FontStyle.Bold);
        Font subTitle = new Font("Verdana", 12, FontStyle.Regular);
        Font content = new Font("Verdana", 10);
        SolidBrush sb = new SolidBrush(Color.Black);

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat st = new StringFormat();
            st.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("MyCafe", Title, sb, 300, 100, st);
            e.Graphics.DrawString("-----------------------------------------------------------", subTitle, sb, 150, 130, st);
            e.Graphics.DrawString("Product Name         Quantity        Price", subTitle, sb, 150, 150, st);
            e.Graphics.DrawString("-----------------------------------------------------------", subTitle, sb, 150, 170, st);
            for (int i = 0; i < lvProducts.Items.Count; i++)
            {
                e.Graphics.DrawString(lvProducts.Items[i].SubItems[0].Text, content, sb, 150, 190 + i * 30, st);
                e.Graphics.DrawString(lvProducts.Items[i].SubItems[1].Text, content, sb, 350, 190 + i * 30, st);
                e.Graphics.DrawString(lvProducts.Items[i].SubItems[3].Text, content, sb, 420, 190 + i * 30, st);
            }
            e.Graphics.DrawString("-----------------------------------------------------------", subTitle, sb, 150, 210 + 30 * lvProducts.Items.Count, st);
            e.Graphics.DrawString("Discount: " + lbDiscount.Text + " TL", subTitle, sb, 150, 210 + 30 * (lvProducts.Items.Count + 1), st);
            e.Graphics.DrawString("Tax: " + lbTax.Text + " TL", subTitle, sb, 150, 210 + 30 * (lvProducts.Items.Count + 2), st);
            e.Graphics.DrawString("Discount: " + lbTotal.Text + " TL", subTitle, sb, 150, 210 + 30 * (lvProducts.Items.Count + 3), st);
            e.Graphics.DrawString("Amount You Paid: " + lbPayable.Text + " TL", subTitle, sb, 150, 210 + 30 * (lvProducts.Items.Count + 4), st);
            e.Graphics.DrawString("-----------------------------------------------------------", subTitle, sb, 150, 210 + 30 * (lvProducts.Items.Count + 5));

        }

     
    }
}
