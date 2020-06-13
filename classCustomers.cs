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
    class classCustomers
    {

        #region Fields
        private int _customerId;
        private string _customerName;
        private string _customerSurname;
        private string _Phone;
        private string _Adress;
        private string _Mail;
        #endregion
        #region Properties
       
        public string CustomerName { get => _customerName; set => _customerName = value; }
        public string CustomerSurname { get => _customerSurname; set => _customerSurname = value; }
        public string Phone { get => _Phone; set => _Phone = value; }
        public string Adress { get => _Adress; set => _Adress = value; }
        public string Mail { get => _Mail; set => _Mail = value; }
        public int CustomerId { get => _customerId; set => _customerId = value; }
        #endregion

        classGeneral gnrl = new classGeneral();

        public bool CheckCustomer(string phn)
        {
            bool result = false;
            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connec;
            cmd.CommandText = ("CheckCustomer");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = phn;
            cmd.Parameters.Add("@result", SqlDbType.Int);
            cmd.Parameters["@result"].Direction = ParameterDirection.Output;
            if (connec.State==ConnectionState.Closed)
            {
                connec.Open();
            }
            try
            {
                cmd.ExecuteNonQuery();
                result = Convert.ToBoolean(cmd.Parameters["@result"].Value);
            }
            catch (SqlException ex)
            {

                string error = ex.Message;
            }
            finally
            {
                connec.Close();
            }
            return result;
        }

        public int AddCustomer(classCustomers c)
        {
            int result = 0;

            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("INSERT INTO customers(name,surname,phone,adress,email)values(@name,@surname,@phone,@adress,@email); SELECT SCOPE_IDENTITY()", connec);
            try
            {
                if (connec.State == ConnectionState.Closed)
                {
                    connec.Open();
                }

                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = c._customerName;
                cmd.Parameters.Add("@surname", SqlDbType.VarChar).Value = c._customerSurname;
                cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = c._Phone;
                cmd.Parameters.Add("@adress", SqlDbType.Text).Value = c._Adress;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = c._Mail;
       

                result = Convert.ToInt32(cmd.ExecuteScalar());

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
       
        public bool UpdateCustomer(classCustomers c)
        {
            bool result = false;

            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("UPDATE customers SET name=@name,surname=@surname,phone=@phone,adress=@adress,email=@email WHERE id=@customerId;", connec);
            try
            {
                if (connec.State == ConnectionState.Closed)
                {
                    connec.Open();
                }

                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = c._customerName;
                cmd.Parameters.Add("@surname", SqlDbType.VarChar).Value = c._customerSurname;
                cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = c._Phone;
                cmd.Parameters.Add("@adress", SqlDbType.VarChar).Value = c._Adress;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = c._Mail;
                cmd.Parameters.Add("@customerId", SqlDbType.VarChar).Value = c._customerId;



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

        public void getCustomer(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("SELECT*FROM customers", connec);
            SqlDataReader dr = null;
           
            try
            {
                if (connec.State == ConnectionState.Closed)
                    connec.Open();
                dr = cmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["id"].ToString());
                    lv.Items[count].SubItems.Add(dr["name"].ToString());
                    lv.Items[count].SubItems.Add(dr["surname"].ToString());
                    lv.Items[count].SubItems.Add(dr["phone"].ToString());
                    lv.Items[count].SubItems.Add(dr["adress"].ToString());
                    lv.Items[count].SubItems.Add(dr["email"].ToString());
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

        public void getCustomerID(int costumerId,TextBox name,TextBox surname,TextBox phone,TextBox adress,TextBox email)
        {

            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("SELECT*FROM customers WHERE id=@costumerID", connec);

            SqlDataReader dr = null;
            cmd.Parameters.Add("costumerID", SqlDbType.Int).Value = costumerId;
            try
            {
                if (connec.State == ConnectionState.Closed)
                    connec.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    name.Text = dr["name"].ToString();
                    surname.Text = dr["surname"].ToString();
                    phone.Text = dr["phone"].ToString();
                    adress.Text = dr["adress"].ToString();
                    email.Text = dr["email"].ToString();
                }
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                
            }
            dr.Close();
            connec.Dispose();
            connec.Close();

        }

        public void getCustomerInformationbyFromName(ListView lv,string customerName)
        {
            lv.Items.Clear();
            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("SELECT*FROM customers WHERE name like @customerName + '%' ", connec);

            SqlDataReader dr = null;
            cmd.Parameters.Add("customerName", SqlDbType.VarChar).Value = customerName;
            try
            {
                if (connec.State == ConnectionState.Closed)
                    connec.Open();
                dr = cmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    lv.Items.Add(Convert.ToInt32(dr["id"]).ToString());
                    lv.Items[count].SubItems.Add(dr["name"].ToString());
                    lv.Items[count].SubItems.Add(dr["surname"].ToString());
                    lv.Items[count].SubItems.Add(dr["phone"].ToString());
                    lv.Items[count].SubItems.Add(dr["adress"].ToString());
                    lv.Items[count].SubItems.Add(dr["email"].ToString());
                    count++;
                }
            }
            catch (SqlException ex)
            {
                string error = ex.Message;

            }
            dr.Close();
            connec.Dispose();
            connec.Close();

        }
    }
}
