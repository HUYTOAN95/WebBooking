using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebBooking.DBConnect
{
    public class DBConnection
    {
        public static SqlConnection cnn;
        /// thông tin server kết nối 
        #region [DBConnection]
        public static void InforConnect(string ser, string db, string user, string pass)
        {
            string cnnstring = "Data Source=" + ser + ";Initial Catalog=" + db + ";User ID=" + user + ";Password=" + pass + ";Integrated Security=True";
            //string cnnstring = "Data Source=127.0.0.1,1433;Initial Catalog=BSHHRM;User ID=admin;Password=admin;Integrated Security=True";
            cnn = new SqlConnection(cnnstring);

        }
        /// hàm mở chuỗi kết nôi
        public static SqlConnection OpenConnection()
        {
            try
            {

                if (cnn.State == ConnectionState.Closed || cnn.State == ConnectionState.Broken)
                    cnn.Open();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return cnn;
        }

        /// hàm đóng kết nối

        public static SqlConnection CloseConnection()
        {
            try
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return cnn;
        }
        #endregion
    }
}