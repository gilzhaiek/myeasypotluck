using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasy.Common;
using MyEasyIDAL.User;
using MyEasyObjects.User;
using System.IO;
using MyEasyObjects.Resource;
using MyEasyObjects.Holding;
using MyEasyObjects.Object;
using System.Data.SqlClient;
using System.Data;

namespace MyEasyDAL.User
{
    public class UserBaseDAL : MyObjectBaseDAL, UserBaseIDAL
    {
        public bool IsLatest(UserBase userBase)
        {
            UserBase upToDateUserBase = new UserBase();

            Load(upToDateUserBase, userBase.UniqueID);

            return (upToDateUserBase.LastDALChange == userBase.LastDALChange);
        }

        // Exceptions:
        //	System.ArgumentException:
        //		userBase is null when saving UserBase
        public void Save(UserBase userBase)
        {
            if (userBase.IsNull)
            {
                throw new System.ArgumentException("userBase is null when saving UserBase", "userBase");
            }

            if (UserBaseExists(userBase.UniqueID))
            {
                UserBase upToDateUserBase = new UserBase();

                try
                {
                    Load(upToDateUserBase, userBase.UniqueID);
                }
                catch
                {
                    SaveInternal(userBase);
                    return;
                }

                if (userBase.CompareTo(upToDateUserBase) != 0)
                    UpdateInternal(userBase);
            }
            else
                SaveInternal(userBase);
        }

        public bool UserBaseExists(UInt64 uniqueID)
        {
            return ObjectBaseExists(uniqueID, "UserBase", "UniqueID");
        }

        public void Load(UserBase userBase, UInt64 uniqueID)
        {
            SqlDataReader sqlReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("select * from UserBase where UniqueID = @1", mSqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
                sqlParameter.Value = uniqueID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlReader = sqlCommand.ExecuteReader();
                if (!sqlReader.Read())
                {
                    throw new System.ArgumentException("userBase with uniqueID=" + uniqueID.ToString() + " was not found", "uniqueID");
                }

                userBase.UniqueID = uniqueID;
                userBase.LastDALChange = Convert.ToInt64(sqlReader["LastDALChange"].ToString());
                userBase.FirstName = sqlReader["FirstName"].ToString();
                userBase.LastName = sqlReader["LastName"].ToString();
                userBase.Email = sqlReader["Email"].ToString();
                userBase.Phone = sqlReader["Phone"].ToString();
                userBase.Gender = (EGender)Enum.Parse(typeof(EGender), sqlReader["EGender"].ToString());
                userBase.Title = (ETitle)Enum.Parse(typeof(ETitle), sqlReader["ETitle"].ToString());
                userBase.Location = new ObjectLocation(Convert.ToUInt64(sqlReader["LocationUniqueID"].ToString()));
                userBase.FBUser = Convert.ToBoolean(sqlReader["FBUser"].ToString());
                userBase.LastFBSync = Convert.ToInt64(sqlReader["LastFBSync"].ToString());

                if (sqlReader.Read())
                {
                    throw new ArgumentException("Multiple UniqueID=" + uniqueID.ToString() + " were found in UserBase", "uniqueID");
                }
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

        protected void UpdateInternal(UserBase userBase)
        {
            try
            {
                userBase.LastDALChange = DateTime.Now.Ticks;

                SqlCommand sqlCommand = new SqlCommand("Update UserBase set " +
                    "LastDALChange='" + userBase.LastDALChange.ToString() + "'," +
                    "FirstName=@FirstName," +
                    "LastName=@LastName," +
                    "Email='" + userBase.Email + "'," +
                    "Phone='" + userBase.Phone + "'," +
                    "EGender='" + userBase.Gender.ToString() + "'," +
                    "ETitle='" + userBase.Title.ToString() + "'," +
                    "LocationUniqueID='" + userBase.Location.UniqueID.ToString() + "'," +
                    "FBUser='" + ((userBase.FBUser) ? "1" : "0") + "'," +
                    "LastFBSync='" + userBase.LastFBSync.ToString() + "' " +
                    "Where UniqueID='" + userBase.UniqueID.ToString() + "'");

                SqlParameter sqlParameter = new SqlParameter("@FirstName", SqlDbType.NVarChar);
                sqlParameter.Value = userBase.FirstName;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("@LastName", SqlDbType.NVarChar);
                sqlParameter.Value = userBase.LastName;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection = mSqlConnection;

                int lineInserted = sqlCommand.ExecuteNonQuery();

                if (lineInserted != 1)
                {
                    throw new System.ArgumentException("Update Into UserBase Where UniqueID=" + userBase.UniqueID.ToString() + " failed", "UniqueID");
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

        protected void SaveInternal(UserBase userBase)
        {
            try
            {
                userBase.LastDALChange = DateTime.Now.Ticks;

                SqlCommand sqlCommand = new SqlCommand("Insert Into UserBase" +
                    " (UniqueID, LastDALChange, FirstName, LastName, Email, Phone, EGender, ETitle, LocationUniqueID, FBUser, LastFBSync) values ('" +
                    userBase.UniqueID.ToString() + "', '" +
                    userBase.LastDALChange.ToString() + "', " +
                    "@FirstName, @LastName , '" +
                    userBase.Email + "', '" +
                    userBase.Phone + "', '" +
                    userBase.Gender.ToString() + "', '" +
                    userBase.Title.ToString() + "', '" +
                    userBase.Location.UniqueID.ToString() + "', '" +
                    ((userBase.FBUser) ? "1" : "0") + "', '" +
                    userBase.LastFBSync + "')");

                SqlParameter sqlParameter = new SqlParameter("@FirstName", SqlDbType.NVarChar);
                sqlParameter.Value = userBase.FirstName;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("@LastName", SqlDbType.NVarChar);
                sqlParameter.Value = userBase.LastName;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection = mSqlConnection;

                int lineInserted = sqlCommand.ExecuteNonQuery();

                if (lineInserted != 1)
                {
                    throw new System.ArgumentException("Insert Into UserBase UniqueID, LastDALChange, FirstName, LastName, Email, Phone, EGender, ETitle, LocationUniqueID, FBUser, LastFBSync) failed", "userBase");
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
    }
}
