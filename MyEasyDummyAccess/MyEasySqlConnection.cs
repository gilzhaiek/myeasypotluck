using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace MyEasyDAL
{
	public class MyEasySqlConnection
	{
		private static SqlConnection	mSqlConnection = null;

		private static void OpenConnection()
		{
			try
			{
				mSqlConnection.Open();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        private static void CloseConnection()
        {
            try
            {
                mSqlConnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


		public static SqlConnection SqlConnection
		{
			get
			{
				if(mSqlConnection == null)
				{
					InitConnection();
				}
				
                if(mSqlConnection.State == System.Data.ConnectionState.Closed)
				{
					OpenConnection();
				}

				return mSqlConnection;
			}
		}
		
		private static void InitConnection()
		{
			if(mSqlConnection != null)
			{
				throw new System.ArgumentException("mSqlConnection is already initialized", "mSqlConnection");
			}

            mSqlConnection = new SqlConnection("Data Source=<WEBSITE>; Initial Catalog=<DB>; User ID=<DB>; Password='<PASSWORD>';connection timeout=20");
            
			OpenConnection();
		}
	}
}
