using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebBooking.DBConnect;
using WebBooking.Models.DataModel;

namespace WebBooking.Business
{
    public class BaseBusiness
    {
        private SqlDataAdapter da = null;

        #region[TransactionProcess]
       /// <summary>
       /// Lấy dữ liệu lên view 
       /// </summary>
       /// <param name="v_comand"></param>
       /// <returns></returns>
        public static SqlDataReader GetData(string v_comand)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(v_comand, DBConnection.cnn);
                cmd.Connection = DBConnection.OpenConnection();
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (DBConnection.OpenConnection() == null)
                {
                    DBConnection.OpenConnection();
                }
            }



        }
      
        /// <summary>
        /// Thêm bản ghi vào database
        /// </summary>
        /// <param name="v_nameprocedure"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public bool CreateData(string v_nameprocedure, SqlParameter[] para)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(v_nameprocedure, DBConnection.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(para);
                DBConnection.OpenConnection();
                //da.InsertCommand = cmd;
                int i = cmd.ExecuteNonQuery();
                if(i>0)
                {
                    return true;
                }
                DBConnection.CloseConnection();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return false;
        }
        // cập nhật thông tin 
        public bool UpdateData(string model)
        {
            return false;
        }

        #endregion
    }
}