using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace cafe
{
    class classSales
    {
        classGeneral gnrl = new classGeneral();
        #region Fields
        private int _Id;
        private int _Addition_Id;
        private int _Product_Id;
        private int _Quantity;
        private int _Table_Id;


        #endregion
        #region Properties
        public int Id { get => _Id; set => _Id = value; }
        public int Addition_Id { get => _Addition_Id; set => _Addition_Id = value; }
        public int Product_Id { get => _Product_Id; set => _Product_Id = value; }
        public int Quantity { get => _Quantity; set => _Quantity = value; }
        public int Table_Id { get => _Table_Id; set => _Table_Id = value; }
        #endregion

        public void getByOrder(ListView lv,int AdditionId)
        {
            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("SELECT product_name,price,sales.id,sales.product_id,sales.quantity FROM sales INNER JOIN products ON sales.product_id=products.id WHERE addition_id=@AdditionId", connec);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@AdditionId", SqlDbType.Int).Value = AdditionId;
            try
            {
                if (connec.State == ConnectionState.Closed)
                {
                    connec.Open();
                }
                dr = cmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["product_name"].ToString());
                    lv.Items[count].SubItems.Add(dr["quantity"].ToString());
                    lv.Items[count].SubItems.Add(dr["product_id"].ToString());
                    lv.Items[count].SubItems.Add(Convert.ToString(Convert.ToDecimal(dr["price"]) * Convert.ToDecimal(dr["quantity"])));
                    lv.Items[count].SubItems.Add(dr["id"].ToString());
                    count++;
                }

            }
            catch (SqlException ex)
            {
                string error = ex.Message;
            }
            finally
            {
                dr.Close();
                connec.Dispose();
                connec.Close();
            }
            
        }

        public bool setSaveOrder(classSales info)
        {
            bool result = false;
            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("INSERT INTO sales(addition_id,product_id,quantity,table_id)values(@Addition_Id,@Product_Id,@Quantity,@Table_Id)", connec);
            try
            {
                if (connec.State == ConnectionState.Closed)
                {
                    connec.Open();
                }
                
                cmd.Parameters.Add("@Addition_Id", SqlDbType.Int).Value = info._Addition_Id;
                cmd.Parameters.Add("@Product_Id", SqlDbType.Int).Value = info._Product_Id;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = info._Quantity;
                cmd.Parameters.Add("@Table_Id", SqlDbType.Int).Value = info._Table_Id;
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

        public void setDeleteOrder(int satisId)
        {
            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("DELETE FROM sales WHERE id=@satisId", connec);
            cmd.Parameters.Add("@satisId", SqlDbType.Int).Value = satisId;
            if (connec.State == ConnectionState.Closed)
            {
                connec.Open();
            }
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connec.Close();
        }
    }
}
