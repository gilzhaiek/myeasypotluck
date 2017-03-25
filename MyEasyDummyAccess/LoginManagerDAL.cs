using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasy.Common;
using MyEasy.MyEasyIDAL;
using System.Data.SqlClient;
using System.Data;

namespace MyEasyDAL
{
    public class LoginManagerDAL : MyObjectBaseDAL, LoginManagerIDAL
	{
		public LoginManagerDAL()
		{
		}

		public UInt64 GetUserUniqueID(string email, string password)
		{
			SqlDataReader	sqlReader = null;
			SqlCommand		sqlCommand = null;

			try
			{
				sqlCommand = new SqlCommand("select * from UsersLoginInfo where Email = @1", mSqlConnection);
				SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.NVarChar);
				sqlParameter.Value = email;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlReader = sqlCommand.ExecuteReader();
				while(sqlReader.Read())
				{
					if(sqlReader["Password"].ToString() == password)
					{
						return Convert.ToUInt64(sqlReader["UniqueID"].ToString());
					}		
				}
                
				return 0;
			}
			catch (Exception exception)
			{
				throw exception;
			}
			finally
			{
				sqlReader.Close();
                mSqlConnection.Close();
			}
		}

		public void UpdateUserLoginInfo(UInt64 uniqueID, string email)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Update UsersLoginInfo set " +
                    "email='" + email + "' " +
                    "Where UniqueID='" + uniqueID.ToString() + "'");

                sqlCommand.Connection = mSqlConnection;

                int lineInserted = sqlCommand.ExecuteNonQuery();

                if (lineInserted != 1)
                {
                    throw new System.ArgumentException("Update UsersLoginInfo Where UniqueID=" + uniqueID.ToString() + " failed", "uniqueID");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                mSqlConnection.Close();
            }
        }

        public void UpdateUserLoginInfo(UInt64 uniqueID, string email, string password)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Update UsersLoginInfo set " +
                    "email='" + email + "'," +
                    "password='" + password + "' " +
                    "Where UniqueID='" + uniqueID.ToString() + "'");

                sqlCommand.Connection = mSqlConnection;

                int lineInserted = sqlCommand.ExecuteNonQuery();

                if (lineInserted != 1)
                {
                    throw new System.ArgumentException("Update UsersLoginInfo Where UniqueID=" + uniqueID.ToString() + " failed", "uniqueID");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                mSqlConnection.Close();
            }
        }

        public void UpdatePassword(string email, string password)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Update UsersLoginInfo set " +
                    "password='" + password + "' " +
                    "Where email='" + email + "'");

                sqlCommand.Connection = mSqlConnection;

                int lineInserted = sqlCommand.ExecuteNonQuery();

                if (lineInserted != 1)
                {
                    throw new System.ArgumentException("Update UsersLoginInfo Where email=" + email + " failed", "email");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                mSqlConnection.Close();
            }
        }

		public void AddUser(UserLoginInfo userLoginInfo)
		{
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Insert Into UsersLoginInfo (Password, Email) values ('" + userLoginInfo.Password + "', '" + userLoginInfo.Email + "') SELECT SCOPE_IDENTITY()");

                sqlCommand.Connection = mSqlConnection;

                userLoginInfo.UniqueID = Convert.ToUInt64(sqlCommand.ExecuteScalar());
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                mSqlConnection.Close();
            }
		}

		public bool LoginNameExists(string loginName)
		{
			SqlDataReader	sqlReader = null;
			SqlCommand		sqlCommand = null;

			try
			{
				//CreateDALConnection();

				sqlCommand = new SqlCommand("select * from UsersLoginInfo where LoginName = @1", mSqlConnection);
				SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.NVarChar);
				sqlParameter.Value = loginName;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlReader = sqlCommand.ExecuteReader();
				return (sqlReader.Read());
			}
			catch (Exception exception)
			{
				throw exception;
			}
			finally
			{
				sqlReader.Close();
                mSqlConnection.Close();
			}
		}

		public bool EmailExists(string email)
		{
			SqlDataReader	sqlReader = null;
			SqlCommand		sqlCommand = null;

			try
			{
				//CreateDALConnection();

                if (mSqlConnection == null)
				{
                    throw new System.ArgumentException("mSqlConnection is null", email);
				}

				sqlCommand = new SqlCommand("select * from UsersLoginInfo where Email = @1", mSqlConnection);
				SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.NVarChar);
				sqlParameter.Value = email;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlReader = sqlCommand.ExecuteReader();
				return (sqlReader.Read());
			}
			catch (Exception exception)
			{
				throw exception;
			}
			finally
			{
				if(sqlReader != null)
					sqlReader.Close();
                mSqlConnection.Close();
			}
		}
	}
}
