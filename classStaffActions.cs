using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe
{
    class classStaffActions
    {
        classGeneral gnl = new classGeneral(); 

        #region Fields
        private int _Id, _StaffId;
        private DateTime _Date;
        private string _Process;
        private bool _Status;
        #endregion
        #region Properties
        public int Id { get => _Id; set => _Id = value; }
        public int StaffId { get => _StaffId; set => _StaffId = value; }
        public DateTime Date { get => _Date; set => _Date = value; }
        public string Process { get => _Process; set => _Process = value; }
        public bool Status { get => _Status; set => _Status = value; } 
        #endregion

        public bool StaffSaveAction(classStaffActions staffact)
        {
            bool result = false;

            SqlConnection connec = new SqlConnection(gnl.connectionStr);
            SqlCommand cmd = new SqlCommand("INSERT INTO staffActions(staff_id,process,date)VALUES(@staff_id,@process,@date)", connec);
            try
            {
                if (connec.State==ConnectionState.Closed)
                {
                    connec.Open();
                }

                cmd.Parameters.Add("@staff_id", SqlDbType.Int).Value = staffact._StaffId;
                cmd.Parameters.Add("@process", SqlDbType.VarChar).Value = staffact._Process;
                cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = staffact._Date;

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());


            }
            catch (SqlException exc)
            {
                string error = exc.Message;
            }
            return result;

        }
    }
}
