using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace cafe
{
    class classPayment
    {
        #region Fields
        private int _Id;
        private int _Addition_Id;
        private int _PaymentMethod_Id;
        private decimal _Subtotal;
        private decimal _Discount;
        private decimal _Tax;
        private decimal _Total;
        private DateTime _Date;
        private int _Customer_Id;


        #endregion
        #region Properties
        public int Id { get => _Id; set => _Id = value; }
        public int Addition_Id { get => _Addition_Id; set => _Addition_Id = value; }
        public int PaymentMethod_Id { get => _PaymentMethod_Id; set => _PaymentMethod_Id = value; }
        public decimal Subtotal { get => _Subtotal; set => _Subtotal = value; }
        public decimal Discount { get => _Discount; set => _Discount = value; }
        public decimal Tax { get => _Tax; set => _Tax = value; }
        public decimal Total { get => _Total; set => _Total = value; }
        public DateTime Date { get => _Date; set => _Date = value; }
        public int Customer_Id { get => _Customer_Id; set => _Customer_Id = value; }
        #endregion

        classGeneral gnrl = new classGeneral();

        public bool billClose(classPayment bill)
        {
            bool result = false;
            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("INSERT INTO paymentActions(addition_id,paymentmethod_id,customer_id,subtotal,tax,discount,total)values(@addition_id,@paymentmethod_id,@customer_id,@subtotal,@tax,@discount,@total)", connec);
           

            try
            {
                if (connec.State==ConnectionState.Closed)
                {
                    connec.Open();
                }
                cmd.Parameters.Add("addition_id", SqlDbType.Int).Value = bill._Addition_Id;
                cmd.Parameters.Add("paymentmethod_id", SqlDbType.Int).Value = bill._PaymentMethod_Id;
                cmd.Parameters.Add("customer_id", SqlDbType.Int).Value = bill._Customer_Id;
                cmd.Parameters.Add("subtotal", SqlDbType.Money).Value = bill._Subtotal;
                cmd.Parameters.Add("tax", SqlDbType.Money).Value = bill._Tax;
                cmd.Parameters.Add("discount", SqlDbType.Money).Value = bill._Discount;
                cmd.Parameters.Add("total", SqlDbType.Money).Value = bill._Total;

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());

            }
            catch (SqlException ex)
            {
                string error = ex.Message;
             
            }
            finally
            {
                connec.Dispose();
                connec.Close();
            }
            return result;
        }

        public decimal sumTotalForCustomerId(int customerId)
        {
            decimal total = 0;

            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("SELECT SUM(total) as Total FROM paymentActions WHERE customer_id=@customerId", connec);

            try
            {
                if (connec.State==ConnectionState.Closed)
                {
                    connec.Open();
                }
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                throw;
            }
            finally
            {
                connec.Dispose();
                connec.Close();
            }



            cmd.Parameters.Add("customerId", SqlDbType.Int).Value = customerId;
            total = Convert.ToDecimal(cmd.ExecuteScalar());
            return total;
        }

    }
}
