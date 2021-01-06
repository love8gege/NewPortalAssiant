using MySql.Data.MySqlClient;
using NewPortalAssiant.Common;
using NewPortalAssiant.DataAccess.DataEntity;
using System;
using System.Configuration;

namespace NewPortalAssiant.DataAccess
{
    public class LocalDataAccess
    {
        private static LocalDataAccess instance;

        private LocalDataAccess() { }

        public static LocalDataAccess GetInstance()
        {
            return instance ?? (instance = new LocalDataAccess());
        }

        MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataReader dr;

        private void Dispose()
        {
            if (dr != null)
            {
                dr.Dispose();
                dr = null;
            }
            if (comm != null)
            {
                comm.Dispose();
                comm = null;
            }
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }

        private bool DBConnection()
        {
            //string conStr = ConfigurationManager.ConnectionStrings["mysqlConn"].ConnectionString;
            string conStr = AppConfig.GetSettingString("mysqlConn");
            if (conn == null)
            {
                conn = new MySqlConnection(conStr);
            }
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception)
            {
                //throw;
                return false;
            }
        }

        public UserEntity CheckUserInfo(string userAccount, string pwd)
        {
            try
            {
                if (DBConnection())
                {
                    string userSql = string.Format("SELECT * From newportalusers  WHERE user_acc='{0}'", userAccount);
                    comm = new MySqlCommand(userSql, conn);
                    dr = comm.ExecuteReader();

                    if (!dr.HasRows)
                    {
                        throw new Exception("用户名或密码不正确！");
                    }

                    UserEntity userInfo = new UserEntity();
                    
                    while (dr.Read())
                    {

                        userInfo.UserAccount = dr["user_acc"].ToString();
                        userInfo.UserPassword = dr["user_psw"].ToString();
                        userInfo.UserName = dr["user_name"].ToString();
                        userInfo.UserPhone = dr["user_phone"].ToString();
                        userInfo.UserLim = dr["user_lim"].ToString();
                        userInfo.UserCert = dr["user_cert"].ToString();
                    }

                    AppConfig.UpdateSettingString("userName", userInfo.UserAccount);
                    AppConfig.UpdateSettingString("password", userInfo.UserPassword);

                    return userInfo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Dispose();
            }

            return null;
        }
    }
}