using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace cafe
{
    class classReservation
    {
        classGeneral gnrl = new classGeneral();
        #region Fields
        private int _Id;
        private int _Table_Id;
        private int _Customer_Id;
        private DateTime _Date;
        private int _Num_Of_People;
        private string _Description;
        private int _Addition_Id;


        #endregion
        #region Properties
        public int Id { get => _Id; set => _Id = value; }
        public int Table_Id { get => _Table_Id; set => _Table_Id = value; }
        public int Customer_Id { get => _Customer_Id; set => _Customer_Id = value; }
        public DateTime Date { get => _Date; set => _Date = value; }
        public int Num_Of_People { get => _Num_Of_People; set => _Num_Of_People = value; }
        public string Description { get => _Description; set => _Description = value; }
        public int Addition_Id { get => _Addition_Id; set => _Addition_Id = value; }
        #endregion

        public int getCustomerIdFromReservations(int tableId)
        {
            int customerId = 0;

            
            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("SELECT top 1 customer_id FROM reservations WHERE table_id=@tableid ORDER BY customer_id DESC", connec);


            try
            {
                if (connec.State == ConnectionState.Closed)
                {
                    connec.Open();
                }
                cmd.Parameters.Add("tableid", SqlDbType.Int).Value = tableId;



                customerId = Convert.ToInt32(cmd.ExecuteNonQuery());

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
         

            return customerId;
        }

        public bool reservationClose(int additionID)
        {
            bool result = false;

            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("UPDATE reservations SET status=0 WHERE addition_id=@additionId", connec);

            try
            {
                if (connec.State == ConnectionState.Closed)
                {
                    connec.Open();
                }

                cmd.Parameters.Add("additionId", SqlDbType.Int).Value = additionID;
                result = Convert.ToBoolean(cmd.ExecuteScalar());


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

    }
}
