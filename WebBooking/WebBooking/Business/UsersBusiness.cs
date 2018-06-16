using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebBooking.Models.DataModel;

namespace WebBooking.Business
{
    public class UsersBusiness : BaseBusiness
    {   /// <summary>
    /// Lấy dữ liệu người dùng lên view 
    /// </summary>
    /// <returns></returns>
        public List<UsersModel> GetUsers()
        {
            List<UsersModel> List = new List<UsersModel>();
            SqlDataReader dr = GetData("SELECT * FROM Users");

            while (dr.Read())
            {
                UsersModel model = new UsersModel();
                model.ID = Int32.Parse(dr[0].ToString());
                model.Name = dr[1].ToString();
                model.UserName = dr[2].ToString();
                model.Password = dr[3].ToString();
                model.Rule = Int16.Parse(dr[4].ToString());
                model.Status = Int16.Parse(dr[5].ToString());
                List.Add(model);
            }
            dr.Close();

            return List;
        }
        /// <summary>
        /// Lấy dữ liệu người dùng lên view theo ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public List<UsersModel> GetUsers_ID(int ? ID)
        {
            List<UsersModel> List = new List<UsersModel>();
            string v_comand = string.Format("SELECT * FROM Users WHERE ID ={0}",ID);
            SqlDataReader dr = GetData(v_comand);

            while (dr.Read())
            {
                UsersModel model = new UsersModel();
                model.ID = Int32.Parse(dr[0].ToString());
                model.Name = dr[1].ToString();
                model.UserName = dr[2].ToString();
                model.Password = dr[3].ToString();
                model.Rule = Int16.Parse(dr[4].ToString());
                model.Status = Int16.Parse(dr[5].ToString());
                List.Add(model);
            }
            dr.Close();

            return List;
        }
        /// <summary>
        /// Thêm thông tin người dùng vào database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CreateUser(UsersModel model)
        {
            try
            {
                string v_nameprc = string.Format("SPUserInsert");
                SqlParameter[] para =
                 {
                    new SqlParameter("@Name", model.Name),
                    new SqlParameter("@UserName", model.UserName),
                    new SqlParameter("@Password", model.Password),
                    new SqlParameter("@Rule", model.Rule),
                    new SqlParameter("@Status", model.Status),

                 };
               bool result =  CreateData(v_nameprc, para);
               if (result==true)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;

        }
    }
}