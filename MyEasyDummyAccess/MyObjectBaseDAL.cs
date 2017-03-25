using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using MyEasy.Common;
using System.Data;

namespace MyEasyDAL
{
	public abstract class MyObjectBaseDAL
	{
		#region Members

		protected SqlConnection	mSqlConnection
		{
			get {return  MyEasySqlConnection.SqlConnection;}
		}

		#endregion

		public MyObjectBaseDAL()
		{
			//mSqlConnection = MyEasySqlConnection.SqlConnection;
		}

		protected bool ObjectBaseExists(UInt64 keyValue, string tableName, string keyName)
		{
			SqlDataReader	sqlReader = null;
			SqlCommand		sqlCommand = null;

            try
            {
                bool rValue;
                sqlCommand = new SqlCommand("select * from " + tableName + " where " + keyName + " = @1", mSqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
                sqlParameter.Value = keyValue;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlReader = sqlCommand.ExecuteReader();
                rValue = sqlReader.Read();

                sqlReader.Close();
                return rValue;
            }
            catch (Exception exception)
            {
                sqlReader.Close();
                throw exception;
            }
            finally
            {
                mSqlConnection.Close();
            }
		}
	}
}
