using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace MyEasyDAL.User
{
    public class UsersConnectionDAL : MyObjectBaseDAL
	{
        public void ResetAllConnections(string user1UniqueID, List<string> user2UniqueIDs)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("DELETE FROM UsersConnection" +
                    " WHERE (User1UniqueID='" + user1UniqueID + "') " +
                    " OR (User2UniqueID='" + user1UniqueID + "')");

                sqlCommand.Connection = mSqlConnection;

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                mSqlConnection.Close();
                throw exception;
            }

            try
            {
                string bulkInserts = "";

                for (int i = 0; i < user2UniqueIDs.Count; i++)
                {
                    if(i > 0)
                        bulkInserts += " , ";
                    bulkInserts += " ('" + user1UniqueID + "','" + user2UniqueIDs[i] + "')";
                }

                SqlCommand sqlCommand = new SqlCommand("Insert Into UsersConnection" +
                    " (User1UniqueID, User2UniqueID) values " + bulkInserts + " ;");

                sqlCommand.Connection = mSqlConnection;

                int lineInserted = sqlCommand.ExecuteNonQuery();
                if (lineInserted != user2UniqueIDs.Count)
                {
                    throw new System.ArgumentException("Insert Into UsersConnection User1UniqueID=" + user1UniqueID + " failed", "user1UniqueID");
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

        public bool ConnectionExists(UInt64 user1UniqueID, UInt64 user2UniqueID)
		{
			SqlDataReader	sqlReader = null;
			SqlCommand		sqlCommand = null;

            try
            {
                bool rValue;
                sqlCommand = new SqlCommand("select * from UsersConnection where User1UniqueID = @1 and User2UniqueID = @2", mSqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
                sqlParameter.Value = user1UniqueID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("@2", SqlDbType.BigInt);
                sqlParameter.Value = user2UniqueID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlReader = sqlCommand.ExecuteReader();
                rValue = sqlReader.Read();

                sqlReader.Close();
                return rValue;
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

        public void AddConnection(UInt64 user1UniqueID, UInt64 user2UniqueID)
		{
			try
			{
				SqlCommand sqlCommand = new SqlCommand("Insert Into UsersConnection" +
					" (User1UniqueID, User2UniqueID) values ('" +
					user1UniqueID.ToString()	+ "', '" + 
					user2UniqueID.ToString()	+ "');");

				sqlCommand.Connection = mSqlConnection;
				
				int lineInserted = sqlCommand.ExecuteNonQuery();

				if(lineInserted != 1)
				{
					throw new System.ArgumentException("Insert Into UsersConnection User1UniqueID=" + user1UniqueID + " and User2UniqueID=" + user2UniqueID + " failed", "user1UniqueID");
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

		public void RemoveConnection(UInt64 user1UniqueID, UInt64 user2UniqueID)
		{
			// Todo
		}

		public List<UInt64> GetConnections(UInt64 userUniqueID)
		{
			List<UInt64>	connectionsList  = new List<UInt64>();
			SqlDataReader	sqlReader = null;
			SqlCommand		sqlCommand = null;

			try
			{
				sqlCommand = new SqlCommand("select * from UsersConnection where User1UniqueID = @1 or User2UniqueID = @2", mSqlConnection);
				SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
				sqlParameter.Value = userUniqueID;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new SqlParameter("@2", SqlDbType.BigInt);
				sqlParameter.Value = userUniqueID;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlReader = sqlCommand.ExecuteReader();

				while(sqlReader.Read())
				{
					UInt64 user1UniqueID = Convert.ToUInt64(sqlReader["User1UniqueID"].ToString());
					UInt64 user2UniqueID = Convert.ToUInt64(sqlReader["User2UniqueID"].ToString());
					if(user1UniqueID != userUniqueID)
						connectionsList.Add(user1UniqueID);
					else if(user2UniqueID != userUniqueID)
						connectionsList.Add(user2UniqueID);
				}

				sqlReader.Close();
				return connectionsList;
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

        public void CloseSqlConnection()
        {
            mSqlConnection.Close();
        }
	}
}
