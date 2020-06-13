using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace cafe
{
    class classPackets
    {
        #region Fields
        private int _Id;
        private int _Addition_Id;
        private int _Customer_Id;
        private string _Description;
        private int _PaymentMethod_Id;
        private int _State;



        #endregion
        #region Properties
        public int Id { get => _Id; set => _Id = value; }
        public int Addition_Id { get => _Addition_Id; set => _Addition_Id = value; }
        public int Customer_Id { get => _Customer_Id; set => _Customer_Id = value; }
        public string Description { get => _Description; set => _Description = value; }
        public int PaymentMethod_Id { get => _PaymentMethod_Id; set => _PaymentMethod_Id = value; }
        public int State { get => _State; set => _State = value; }
        #endregion

        classGeneral gnrl = new classGeneral();

        public bool packageOrderOpen(classPackets order)
        {
            bool result = false;
            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("INSERT INTO packageOrder(addition_id,customer_id,paymentmethod_id,description)values(@addition_id,@customer_id,@paymentmethod_id,@description)", connec);
            try
            {
                if (connec.State==ConnectionState.Closed)
                {
                    connec.Open();
                }
                cmd.Parameters.Add("@addition_id", SqlDbType.Int).Value = order.Addition_Id;
                cmd.Parameters.Add("@customer_id", SqlDbType.Int).Value = order.Customer_Id;
                cmd.Parameters.Add("@paymentmethod_id", SqlDbType.Int).Value = order.PaymentMethod_Id;
                cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = order.Description;
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());


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
            return result;


        }

        public void packageOrderClose(int AdditionId)
        {

            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("UPDATE packageOrder SET packageOrder.status=1 FROM packageOrder INNER JOIN additions ON packageOrder.addition_id=additions.id WHERE packageOrder.addition_id=@AdditionId", connec);
            try
            {
                if (connec.State == ConnectionState.Closed)
                {
                    connec.Open();
                }
                cmd.Parameters.Add("@AdditionId", SqlDbType.Int).Value = AdditionId;

                Convert.ToBoolean(cmd.ExecuteNonQuery());

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


        }

        public int getPaymentMethodId(int adisyonId)
        {
            int paymentmethodId = 0;
            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("SELECT packageOrder.paymentmethod_id FROM packageOrder INNER JOIN additions ON packageOrder.addition_id=additions.id WHERE additions.id=@AdditionId", connec);
            try
            {
                if (connec.State == ConnectionState.Closed)
                {
                    connec.Open();
                }
                cmd.Parameters.Add("@adisyonId", SqlDbType.Int).Value = adisyonId;


                paymentmethodId = Convert.ToInt32(cmd.ExecuteScalar());


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

            return paymentmethodId;
        }

        public int getCustomerLastAdditionId(int customerId)
        {
            int no = 0;
            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("SELECT additions.id FROM additions INNER JOIN packageOrder ON packageOrder.addition_id=additions.id WHERE (additions.status=0) AND (packageOrder.status=0) AND (packageOrder.customer_id=@customerId)", connec);
            try
            {
                if (connec.State == ConnectionState.Closed)
                {
                    connec.Open();
                }
                cmd.Parameters.Add("@customerId", SqlDbType.Int).Value = customerId;


                no = Convert.ToInt32(cmd.ExecuteScalar());


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

            return no;
        }

        public bool getCheckOpenAdditionId(int additionId)
        {
            bool result = false;
            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("SELECT * FROM additions WHERE (state=0) AND (id=@additionId)", connec);
            try
            {
                if (connec.State == ConnectionState.Closed)
                {
                    connec.Open();
                }
                cmd.Parameters.Add("@additionId", SqlDbType.Int).Value = additionId;
                result = Convert.ToBoolean(cmd.ExecuteScalar());


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

    }
}
