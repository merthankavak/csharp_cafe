using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe
{
    class classAdditions
    {
        classGeneral gnrl = new classGeneral();
       
        #region fields
        private int _Id;
        private int _ServiceType_Id;
        private decimal _Price;
        private DateTime _Date;
        private int _Staff_Id;
        private int _Status;
        private int _Table_Id;
        #endregion

        #region Properties
        public int Id { get => _Id; set => _Id = value; }
        public int ServiceType_Id { get => _ServiceType_Id; set => _ServiceType_Id = value; }
        public decimal Price { get => _Price; set => _Price = value; }
        public DateTime Date { get => _Date; set => _Date = value; }
        public int Staff_Id { get => _Staff_Id; set => _Staff_Id = value; }
        public int Status { get => _Status; set => _Status = value; }
        public int Table_Id { get => _Table_Id; set => _Table_Id = value; }
        #endregion

        public int getByAddition(int Table_Id)
        {
            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("SELECT top 1 id FROM additions WHERE table_id=@Table_Id ORDER BY id DESC", connec);
            cmd.Parameters.Add("@Table_Id", SqlDbType.Int).Value = Table_Id;
            try
            {
                if (connec.State == ConnectionState.Closed)
                {
                    connec.Open();
                }
                Table_Id = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (SqlException ex)
            {
                string error = ex.Message;
            }
            finally
            {               
                connec.Close();
            }
            return Table_Id;

        }

        public bool setByAdditionNew(classAdditions info)
        {
            bool result = false;
            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("INSERT INTO additions(servicetype_id,date,staff_id,table_id,status) VALUES(@ServiceType_Id,@Date,@Staff_Id,@Table_Id,@Status) ", connec);
            try
            {
                if (connec.State == ConnectionState.Closed)
                {
                    connec.Open();
                }
                cmd.Parameters.Add("@ServiceType_Id", SqlDbType.Int).Value = info.ServiceType_Id;
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = info.Date;
                cmd.Parameters.Add("@Staff_Id", SqlDbType.Int).Value = info.Staff_Id;
                cmd.Parameters.Add("@Table_Id", SqlDbType.Int).Value = info.Table_Id;
                cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = 0;
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

        public void additionClose(int additionID,int status)
        {


            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("UPDATE additions SET status=@status WHERE id=@additionId", connec);

            try
            {
                if (connec.State == ConnectionState.Closed)
                {
                    connec.Open();
                }

                cmd.Parameters.Add("additionId", SqlDbType.Int).Value = additionID;
                cmd.Parameters.Add("status", SqlDbType.Int).Value = status;
                cmd.ExecuteNonQuery();

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

    }
}
