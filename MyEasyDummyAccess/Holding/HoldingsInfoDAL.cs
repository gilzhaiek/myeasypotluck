using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyObjects.Holding;
using MyEasy.Common;
using MyEasyIDAL.HoldingsIDAL;
using MyEasyObjects.Resource;
using MyEasyObjects.User;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using MyEasyObjects.Event;
using MyEasyObjects.Item;

namespace MyEasyDAL.Holding
{
    public class HoldingsInfoDAL : MyObjectBaseDAL, HoldingsInfoIDAL
    {
        public bool IsLatest(HoldingsInfo holdingsInfo)
        {
            HoldingsInfo upToDateHoldingsInfo = new HoldingsInfo();

            Load(upToDateHoldingsInfo, holdingsInfo.UniqueID);

            return (upToDateHoldingsInfo.LastDALChange == holdingsInfo.LastDALChange);
        }

        // Exceptions:
        //	System.ArgumentException:
        //		holdingsInfo is null when saving HoldingsInfo
        public void Save(HoldingsInfo holdingsInfo)
        {
            if (holdingsInfo.IsNull)
            {
                SaveInternal(holdingsInfo);
                return;
                //throw new System.ArgumentException("holdingsInfo is null when saving HoldingsInfo", "holdingsInfo");
            }

            if (HoldingsInfoExists(holdingsInfo.UniqueID))
            {
                HoldingsInfo upToDateItemBase = new HoldingsInfo();

                try
                {
                    Load(upToDateItemBase, holdingsInfo.UniqueID);
                }
                catch
                {
                    SaveInternal(holdingsInfo);
                    return;
                }

                if (holdingsInfo.CompareTo(upToDateItemBase) != 0)
                    UpdateInternal(holdingsInfo);
            }
            else
                SaveInternal(holdingsInfo);
        }

        // Exceptions:
        //	System.ArgumentException:
        public void Delete(HoldingsInfo holdingsInfo)
        {
            if (holdingsInfo.IsNull)
            {
                throw new System.ArgumentException("holdingsInfo is null when removing HoldingsInfo", "holdingsInfo");
            }

            if (HoldingsInfoExists(holdingsInfo.UniqueID))
            {
                DeleteInternal(holdingsInfo);
            }
            else
                throw new System.ArgumentException("holdingsInfo does not exists while removing HoldingsInfo", "holdingsInfo");
        }

        public bool HoldingsInfoExists(UInt64 uniqueID)
        {
            SqlDataReader sqlReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                bool rValue;
                sqlCommand = new SqlCommand("select * from HoldingsInfo where UniqueID = @1", mSqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
                sqlParameter.Value = uniqueID;
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
        }

        public void Load(HoldingsInfo holdingsInfo, UInt64 uniqueID)
        {
            SqlDataReader sqlReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("select * from HoldingsInfo where UniqueID = @1", mSqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
                sqlParameter.Value = uniqueID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlReader = sqlCommand.ExecuteReader();
                if (!sqlReader.Read())
                {
                    throw new System.ArgumentException("holdingsInfo with UniqueID=" + uniqueID.ToString() + " was not found", "uniqueID");
                }

                holdingsInfo.UniqueID = uniqueID;
                holdingsInfo.LastDALChange = Convert.ToInt64(sqlReader["LastDALChange"].ToString());
                holdingsInfo.HoldingUser = new UserBase(Convert.ToUInt64(sqlReader["HoldingUserUniqueID"].ToString()));
                holdingsInfo.HoldingUserPermissions = (EHoldingPermissions)Enum.Parse(typeof(EHoldingPermissions), sqlReader["EHoldingPermissions"].ToString());
                holdingsInfo.EventOwner = new EventBase(Convert.ToUInt64(sqlReader["EventOwnerUniqueID"].ToString()));
                holdingsInfo.ItemOwner = new ItemBase(Convert.ToUInt64(sqlReader["ItemOwnerUniqueID"].ToString()));
                holdingsInfo.AllowOverBooking = Convert.ToBoolean(sqlReader["AllowOverBooking"].ToString());
                holdingsInfo.Scalable = Convert.ToBoolean(sqlReader["Scalable"].ToString());
                holdingsInfo.NeedsOwnerApprovel = Convert.ToBoolean(sqlReader["NeedsOwnerApprovel"].ToString());
                holdingsInfo.HoldingApprovel = (EHoldingApprovel)Enum.Parse(typeof(EHoldingApprovel), sqlReader["EHoldingApprovel"].ToString());

                if (sqlReader.Read())
                {
                    throw new ArgumentException("Multiple UniqueID=" + uniqueID.ToString() + " were found in HoldingsInfo", "uniqueID");
                }
                sqlReader.Close();

                sqlCommand = new SqlCommand("select * from UserPermission where HoldingInfoUniqueID = @1", mSqlConnection);
                sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
                sqlParameter.Value = uniqueID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlReader = sqlCommand.ExecuteReader();
                /*if(!sqlReader.Read())
				{
					throw new System.ArgumentException("UserPermission with HoldingInfoUniqueID=" + uniqueID.ToString() + " was not found", "uniqueID");
				}*/

                if (sqlReader != null)
                {
                    while (sqlReader.Read())
                    {
                        UserPermission userPermission = new UserPermission(uniqueID);

                        userPermission.UserBase = new UserBase(Convert.ToUInt64(sqlReader["UserBaseUniqueID"].ToString()));
                        userPermission.HoldingPermission = (EHoldingPermissions)Enum.Parse(typeof(EHoldingPermissions), sqlReader["EHoldingPermission"].ToString());

                        holdingsInfo.UserPermissions.Add(userPermission);
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                sqlReader.Close();
            }
        }

        protected void UpdateInternal(HoldingsInfo holdingsInfo)
        {
            try
            {
                holdingsInfo.LastDALChange = DateTime.Now.Ticks;

                SqlCommand sqlCommand = new SqlCommand("Update HoldingsInfo set " +
                    "LastDALChange='" + holdingsInfo.LastDALChange.ToString() + "'," +
                    "HoldingUserUniqueID='" + holdingsInfo.HoldingUser.UniqueID.ToString() + "'," +
                    "EHoldingPermissions='" + holdingsInfo.HoldingUserPermissions.ToString() + "'," +
                    "EventOwnerUniqueID='" + holdingsInfo.EventOwner.UniqueID.ToString() + "'," +
                    "ItemOwnerUniqueID='" + holdingsInfo.ItemOwner.UniqueID.ToString() + "'," +
                    "AllowOverBooking='" + holdingsInfo.AllowOverBooking.ToString() + "'," +
                    "Scalable='" + holdingsInfo.Scalable.ToString() + "'," +
                    "NeedsOwnerApprovel='" + holdingsInfo.NeedsOwnerApprovel.ToString() + "'," +
                    "EHoldingApprovel='" + holdingsInfo.HoldingApprovel.ToString() + "' " +
                    "Where UniqueID='" + holdingsInfo.UniqueID.ToString() + "'");

                sqlCommand.Connection = mSqlConnection;

                int lineInserted = sqlCommand.ExecuteNonQuery();

                if (lineInserted != 1)
                {
                    throw new System.ArgumentException("Update Into HoldingsInfo Where UniqueID=" + holdingsInfo.UniqueID.ToString() + " failed", "UniqueID");
                }

                foreach (UserPermission userPermission in holdingsInfo.UserPermissions)
                {
                    sqlCommand = new SqlCommand("Update UserPermission set " +
                        "UserBaseUniqueID='" + userPermission.UserBase.UniqueID.ToString() + "'," +
                        "EHoldingPermission='" + userPermission.HoldingPermission.ToString() + "' " +
                        "Where HoldingInfoUniqueID='" + holdingsInfo.UniqueID.ToString() + "'");

                    sqlCommand.Connection = mSqlConnection;

                    lineInserted = sqlCommand.ExecuteNonQuery();

                    if (lineInserted != 1)
                    {
                        throw new System.ArgumentException("Update Into HoldingsInfo Where UniqueID=" + holdingsInfo.UniqueID.ToString() + " failed", "UniqueID");
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void SaveInternal(HoldingsInfo holdingsInfo)
        {
            try
            {
                holdingsInfo.LastDALChange = DateTime.Now.Ticks;

                SqlCommand sqlCommand = new SqlCommand("Insert Into HoldingsInfo" +
                    " (LastDALChange, HoldingUserUniqueID, EHoldingPermissions, EventOwnerUniqueID, ItemOwnerUniqueID, AllowOverBooking, Scalable, NeedsOwnerApprovel, EHoldingApprovel) values ('" +
                    holdingsInfo.LastDALChange.ToString() + "', '" +
                    holdingsInfo.HoldingUser.UniqueID.ToString() + "', '" +
                    holdingsInfo.HoldingUserPermissions.ToString() + "', '" +
                    holdingsInfo.EventOwner.UniqueID.ToString() + "', '" +
                    holdingsInfo.ItemOwner.UniqueID.ToString() + "', '" +
                    holdingsInfo.AllowOverBooking.ToString() + "', '" +
                    holdingsInfo.Scalable.ToString() + "', '" +
                    holdingsInfo.NeedsOwnerApprovel.ToString() + "', '" +
                    holdingsInfo.HoldingApprovel.ToString() + "');" +
                    "SELECT SCOPE_IDENTITY()");

                sqlCommand.Connection = mSqlConnection;

                holdingsInfo.UniqueID = Convert.ToUInt64(sqlCommand.ExecuteScalar());

                foreach (UserPermission userPermission in holdingsInfo.UserPermissions)
                {
                    sqlCommand = new SqlCommand("Insert Into UserPermission" +
                        " (HoldingInfoUniqueID, UserBaseUniqueID, EHoldingPermission) values ('" +
                        holdingsInfo.UniqueID.ToString() + "', '" +
                        userPermission.UserBase.UniqueID.ToString() + "', '" +
                        userPermission.HoldingPermission.ToString() + "');");

                    sqlCommand.Connection = mSqlConnection;

                    int lineInserted = sqlCommand.ExecuteNonQuery();

                    if (lineInserted != 1)
                    {
                        throw new System.ArgumentException("Insert Into UserPermission UniqueID=" + holdingsInfo.UniqueID.ToString() + " failed", "userPermission");
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void DeleteInternal(HoldingsInfo holdingsInfo)
        {
            try
            {
                SqlCommand sqlCommand;
                int lineRemoved;

                foreach (UserPermission userPermission in holdingsInfo.UserPermissions)
                {
                    sqlCommand = new SqlCommand("delete from UserPermission where " +
                                "HoldingInfoUniqueID = '" + holdingsInfo.UniqueID.ToString() + "';");

                    sqlCommand.Connection = mSqlConnection;

                    lineRemoved = sqlCommand.ExecuteNonQuery();

                    if (lineRemoved != 1)
                    {
                        throw new System.ArgumentException("Delete from UserPermission Where HoldingInfoUniqueID=" + holdingsInfo.UniqueID.ToString() + " failed", "UniqueID");
                    }
                }

                holdingsInfo.LastDALChange = DateTime.Now.Ticks;

                sqlCommand = new SqlCommand("delete from HoldingsInfo where " +
                            "UniqueID = '" + holdingsInfo.UniqueID.ToString() + "';");

                sqlCommand.Connection = mSqlConnection;

                lineRemoved = sqlCommand.ExecuteNonQuery();

                if (lineRemoved != 1)
                {
                    throw new System.ArgumentException("Delete from HoldingsInfo Where UniqueID=" + holdingsInfo.UniqueID.ToString() + " failed", "UniqueID");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<UInt64> GetUniqueIDsByEventOwner(UInt64 eventOwnerUniqueID)
        {
            List<UInt64> uniqueIDList = new List<UInt64>();

            SqlDataReader sqlReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("select UniqueID from HoldingsInfo where EventOwnerUniqueID = @1", mSqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
                sqlParameter.Value = eventOwnerUniqueID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    uniqueIDList.Add(Convert.ToUInt64(sqlReader["UniqueID"].ToString()));
                }

                sqlReader.Close();
                return uniqueIDList;
            }
            catch (Exception exception)
            {
                sqlReader.Close();
                throw exception;
            }
        }

        public List<UInt64> GetEventsUniqueIDByHolderUniqueID(UInt64 holdingUserUniqueID)
        {
            List<UInt64> uniqueIDList = new List<UInt64>();

            SqlDataReader sqlReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("select EventOwnerUniqueID from HoldingsInfo where HoldingUserUniqueID = @1 and ItemOwnerUniqueID = @2", mSqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
                sqlParameter.Value = holdingUserUniqueID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("@2", SqlDbType.BigInt);
                sqlParameter.Value = 0;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    uniqueIDList.Add(Convert.ToUInt64(sqlReader["EventOwnerUniqueID"].ToString()));
                }

                sqlReader.Close();
                return uniqueIDList;
            }
            catch (Exception exception)
            {
                sqlReader.Close();
                throw exception;
            }
        }

        public List<UInt64> GetUniqueIDsByItemOwner(UInt64 itemOwnerUniqueID)
        {
            List<UInt64> uniqueIDList = new List<UInt64>();

            SqlDataReader sqlReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("select UniqueID from HoldingsInfo where ItemOwnerUniqueID = @1", mSqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
                sqlParameter.Value = itemOwnerUniqueID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    uniqueIDList.Add(Convert.ToUInt64(sqlReader["UniqueID"].ToString()));
                }

                sqlReader.Close();
                return uniqueIDList;
            }
            catch (Exception exception)
            {
                sqlReader.Close();
                throw exception;
            }
        }

    }
}
