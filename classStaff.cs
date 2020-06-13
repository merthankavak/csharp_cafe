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
    class classStaff    
    {
       classGeneral gnrl=new classGeneral();

        #region Fields
        private int _StaffId, _StaffTaskId;
        private string _StaffName, _StaffSurname, _StaffPhone, _StaffAdress, _StaffEmail, _StaffUsername, _StaffPassword;
        private bool _StaffStatus;
        #endregion
        #region Properties
        public int StaffId { get => _StaffId; set => _StaffId = value; }
        public int StaffTaskId { get => _StaffTaskId; set => _StaffTaskId = value; }
        public string StaffName { get => _StaffName; set => _StaffName = value; }
        public string StaffSurname { get => _StaffSurname; set => _StaffSurname = value; }
        public string StaffPhone { get => _StaffPhone; set => _StaffPhone = value; }
        public string StaffAdress { get => _StaffAdress; set => _StaffAdress = value; }
        public string StaffEmail { get => _StaffEmail; set => _StaffEmail = value; }
        public string StaffUsername { get => _StaffUsername; set => _StaffUsername = value; }
        public string StaffPassword { get => _StaffPassword; set => _StaffPassword = value; }
        public bool StaffStatus { get => _StaffStatus; set => _StaffStatus = value; } 
        #endregion

        public bool staffLoginControl(string password,int userId)
        {
            bool result = false;

            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("SELECT*FROM staff WHERE id=@id AND password=@password", connec);
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = userId;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

            try
            {
                if (connec.State == ConnectionState.Closed)
                {
                    connec.Open();
                }
                result = Convert.ToBoolean(cmd.ExecuteScalar());

            }
            catch (SqlException exc)
            {
                string error = exc.Message;
                throw;
            }


            return result;
        }

        public void staffGetInfo(ComboBox cb)
        {
            cb.Items.Clear();

            SqlConnection connec = new SqlConnection(gnrl.connectionStr);
            SqlCommand cmd = new SqlCommand("SELECT*FROM staff", connec);
            
         
            if (connec.State == ConnectionState.Closed)
            {
                connec.Open();

            }
            SqlDataReader datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {
                classStaff stf = new classStaff();
                stf._StaffId = Convert.ToInt32(datareader["id"]);
                stf._StaffTaskId = Convert.ToInt32(datareader["task_id"]);
                stf._StaffName = Convert.ToString(datareader["name"]);
                stf._StaffSurname = Convert.ToString(datareader["surname"]);
                stf._StaffAdress = Convert.ToString(datareader["adress"]);
                stf._StaffEmail = Convert.ToString(datareader["email"]);
                stf._StaffPhone = Convert.ToString(datareader["phone"]);
                stf._StaffUsername = Convert.ToString(datareader["username"]);
                stf._StaffPassword = Convert.ToString(datareader["password"]);
                stf._StaffStatus = Convert.ToBoolean(datareader["status"]);
                cb.Items.Add(stf);
            }
            datareader.Close();
            connec.Close();

        }
        
        public override string ToString()
        {
            return StaffName+ StaffSurname;
        }

    }
}
