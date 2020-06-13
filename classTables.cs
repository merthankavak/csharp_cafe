using FlaUI.Core.AutomationElements;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace cafe
{
    class classTables
    {
        #region Fields
        private int _id, _capacity, _servicetype, _status, _confirm;
        #endregion
        #region Properties

        public int id { get => _id; set => _id = value; }
        public int capacity { get => _capacity; set => _capacity = value; }
        public int servicetype { get => _servicetype; set => _servicetype = value; }
        public int status { get => _status; set => _status = value; }
        public int confirm { get => _confirm; set => _confirm = value; }

        #endregion

        classGeneral gnrl = new classGeneral();

        public string SessionSum(int status,string tableId)
        {
            string dt = "";
            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("SELECT date,table_id FROM additions RIGHT JOIN tables on additions.table_id=tables.id WHERE tables.status=@status AND additions.status=0 AND tables.id=@tableId", connec);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@status", SqlDbType.Int).Value = status;
            cmd.Parameters.Add("@tableId", SqlDbType.Int).Value = Convert.ToInt32(tableId);

            try
            {
                if (connec.State==ConnectionState.Closed)
                {
                    connec.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dt = Convert.ToDateTime(dr["date"]).ToString();
                }
            }
            catch (SqlException ex)
            {
                string error = ex.Message;

                throw;
            }
            finally {
                dr.Close();
                connec.Dispose();
                connec.Close();
            }
            return dt;
        
        }

        public int TableGetbyNumber(string TableValue)
        {
            string a = TableValue;
            int length = a.Length;
            return Convert.ToInt32(a.Substring(length-1,1));
        }

        public bool TableGetbyState(int ButtonName,int state)
        {
            bool result = false;
            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("SELECT status FROM tables WHERE id=@id and status=@status", connec);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = ButtonName;
            cmd.Parameters.Add("@status", SqlDbType.Int).Value = state;
            try
            {
                if (connec.State == ConnectionState.Closed)
                {
                    connec.Open();
                }
                result= Convert.ToBoolean(cmd.ExecuteScalar());

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

        public void setChangeTableState(string ButtonName,int state)
        {
            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("UPDATE tables SET status=@status WHERE id=@id", connec);
            if (connec.State==ConnectionState.Closed)
            {
                connec.Open();
            }
            string a = ButtonName;
            int length = a.Length;
            cmd.Parameters.Add("@status", SqlDbType.Int).Value = state;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = a.Substring(length - 1, 1);
            cmd.ExecuteNonQuery();
            connec.Dispose();
            connec.Close();
        }
    }
}
