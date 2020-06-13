using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafe
{
    class classProductType
    {
        classGeneral gnrl= new classGeneral();
        #region Fields
        private int _ProductTypeNo;
        private string _CategoryName;
        private string _Description;


        #endregion
        #region Properties
        public int ProductTypeNo { get => _ProductTypeNo; set => _ProductTypeNo = value; }
        public string CategoryName { get => _CategoryName; set => _CategoryName = value; }
        public string Description { get => _Description; set => _Description = value; }
        #endregion

        public void getByProductTypes(ListView Types,Button btn)
        {
            Types.Items.Clear();
            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("SELECT product_name,price,products.id FROM categories INNER JOIN products ON categories.id=products.category_id WHERE products.category_id=@category_id", connec);
            string a = btn.Name;
            int length = a.Length;
            cmd.Parameters.Add("@category_id", SqlDbType.Int).Value = a.Substring(length-1, 1);
            if (connec.State == ConnectionState.Closed)
            {
                connec.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                Types.Items.Add(dr["product_name"].ToString());
                Types.Items[i].SubItems.Add(dr["price"].ToString());
                Types.Items[i].SubItems.Add(dr["id"].ToString());
                i++;
            }
            dr.Close();
            connec.Dispose();
            connec.Close();
        
        }

        public void getByProductSearch(ListView Types, int txt)
        {
            Types.Items.Clear();
            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("SELECT * FROM products WHERE id=@id", connec);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = txt;
            if (connec.State == ConnectionState.Closed)
            {
                connec.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                Types.Items.Add(dr["product_name"].ToString());
                Types.Items[i].SubItems.Add(dr["price"].ToString());
                Types.Items[i].SubItems.Add(dr["id"].ToString());
                i++;
            }
            dr.Close();
            connec.Dispose();
            connec.Close();

        }

    }
}
