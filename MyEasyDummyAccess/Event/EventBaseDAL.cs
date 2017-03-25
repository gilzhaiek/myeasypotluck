using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyIDAL.Event;
using MyEasyObjects.Event;
using System.Data.SqlClient;
using MyEasyObjects.Item;
using MyEasyDAL.Item;
using System.Data;
using MyEasyObjects.User;
using MyEasyObjects.Resource;
using MyEasy.Common;
using MyEasyObjects.Object;

namespace MyEasyDAL.Event
{
	public class EventBaseDAL : MyObjectBaseDAL, EventBaseIDAL
	{
		#region Members

		ItemBaseDAL		mItemBaseDAL;

		#endregion

		public EventBaseDAL()
		{
			mItemBaseDAL	= new ItemBaseDAL();
		}

		public bool IsLatest(EventBase eventBase, bool checkRelations)
		{
			EventBase upToDateEventBase = new EventBase();

			Load(upToDateEventBase, eventBase.UniqueID);

			if(upToDateEventBase.LastDALChange != eventBase.LastDALChange)
				return false;
			
			if(checkRelations)
			{
				foreach(EventBase eventChild in eventBase.EventChildren)
				{
					if(!IsLatest(eventChild, false))
						return false;
				}

				foreach(ItemBase itemChild in eventBase.ItemChildren)
				{
					if(!mItemBaseDAL.IsLatest(itemChild, false))
						return false;
				}
			}

			return true;
		}

		// Exceptions:
		//	System.ArgumentException:
		//		eventBase is null when saving EventBase
		public void	Save(EventBase eventBase)
		{
			if(eventBase.IsNull)
			{
				SaveInternal(eventBase);
				return;
				//throw new System.ArgumentException("eventBase is null when saving EventBase", "eventBase");
			}

			if(EventBaseExists(eventBase.UniqueID))
			{
				EventBase upToDateEventBase = new EventBase();

				try
				{
					Load(upToDateEventBase, eventBase.UniqueID);
				}
				catch
				{
					SaveInternal(eventBase);
					return;
				}

				if(eventBase.CompareTo(upToDateEventBase) != 0)
					UpdateInternal(eventBase);
			}
			else
				SaveInternal(eventBase);
		}

        public void Delete(EventBase eventBase)
        {
            if (eventBase.IsNull)
            {
                throw new System.ArgumentException("eventBase is null when removing EventBase", "eventBase");
            }

            if (EventBaseExists(eventBase.UniqueID))
            {
                DeleteInternal(eventBase);
            }
            else
                throw new System.ArgumentException("eventBase does not exists while removing EventBase", "eventBase");
        }


		public bool EventBaseExists(UInt64 uniqueID)
		{
            return ObjectBaseExists(uniqueID, "EventBase", "UniqueID");
		}

		public void Load(EventBase eventBase, UInt64 uniqueID)
		{
			SqlDataReader	sqlReader = null;
			SqlCommand		sqlCommand = null;

			try
			{
				sqlCommand = new SqlCommand("select * from EventBase where UniqueID = @1", mSqlConnection);
				SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
				sqlParameter.Value = uniqueID;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlReader = sqlCommand.ExecuteReader();
				if(!sqlReader.Read())
				{
					throw new System.ArgumentException("eventBase with uniqueID=" + uniqueID.ToString() + " was not found", "uniqueID");
				}
				
				eventBase.UniqueID				= uniqueID;
				eventBase.LastDALChange			= Convert.ToInt64(sqlReader["LastDALChange"].ToString());
				eventBase.Admin					= new UserBase(Convert.ToUInt64(sqlReader["AdminUniqueID"].ToString()));
				eventBase.ResourcePriority		= (EResourcePriority)Enum.Parse(typeof(EResourcePriority), sqlReader["ResourcePriority"].ToString());
				eventBase.Scalable				= Convert.ToBoolean(sqlReader["Scalable"].ToString());
				eventBase.EventParent			= new EventBase(Convert.ToUInt64(sqlReader["EventParentUniqueID"].ToString()));
				eventBase.EventLocation			= new ObjectLocation(Convert.ToUInt64(sqlReader["EventLocationUniqueID"].ToString()));
				eventBase.Value					= Convert.ToInt32(sqlReader["Value"].ToString());
				eventBase.IsPublic				= Convert.ToBoolean(sqlReader["IsPublic"].ToString());
                eventBase.PrivacyType           = (EPrivacyType)Enum.Parse(typeof(EPrivacyType), sqlReader["PrivacyType"].ToString());
                eventBase.FullImageLocation     = sqlReader["FullImageLocation"].ToString();
                eventBase.ThumbImageLocation    = sqlReader["ThumbImageLocation"].ToString();
                eventBase.MaxHoldings           = Convert.ToInt32(sqlReader["MaxHoldings"].ToString());

				if(sqlReader.Read())
				{
					throw new ArgumentException("Multiple UniqueID=" + uniqueID.ToString() + " were found in EventBase", "uniqueID");
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

		protected void UpdateInternal(EventBase eventBase)
		{
			try
			{
				eventBase.LastDALChange = DateTime.Now.Ticks;

				SqlCommand sqlCommand = new SqlCommand("Update EventBase set " +
					"LastDALChange='"			+ eventBase.LastDALChange.ToString()			+ "'," + 
					"AdminUniqueID='"			+ eventBase.Admin.UniqueID.ToString()			+ "'," + 
					"ResourcePriority='"		+ eventBase.ResourcePriority.ToString()			+ "'," + 
					"Scalable='"				+ eventBase.Scalable.ToString()					+ "'," + 
					"EventParentUniqueID='"		+ eventBase.EventParent.UniqueID.ToString()		+ "'," + 
					"EventLocationUniqueID='"	+ eventBase.EventLocation.UniqueID.ToString()	+ "'," + 
					"Value='"					+ eventBase.Value.ToString()					+ "'," +
                    "IsPublic='"                + eventBase.IsPublic.ToString()                 + "'," +
                    "PrivacyType='"             + eventBase.PrivacyType.ToString()              + "'," +
                    "FullImageLocation='"       + eventBase.FullImageLocation                   + "'," +
                    "ThumbImageLocation='"      + eventBase.ThumbImageLocation                  + "'," +
                    "MaxHoldings='"             + eventBase.MaxHoldings.ToString()              + "' " +
					"Where UniqueID='"			+ eventBase.UniqueID.ToString()                 + "'");

				sqlCommand.Connection = mSqlConnection;
				
				int lineInserted = sqlCommand.ExecuteNonQuery();

				if(lineInserted != 1)
				{
					throw new System.ArgumentException("Update Into EventBase Where UniqueID=" + eventBase.UniqueID.ToString() + " failed", "UniqueID");
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

		protected void SaveInternal(EventBase eventBase)
		{
            try
            {
                eventBase.LastDALChange = DateTime.Now.Ticks;

                SqlCommand sqlCommand = new SqlCommand("Insert Into EventBase" +
                    " (LastDALChange, AdminUniqueID, ResourcePriority, Scalable, EventParentUniqueID, EventLocationUniqueID, Value, IsPublic, PrivacyType, FullImageLocation, ThumbImageLocation, MaxHoldings) values ('" +
                    eventBase.LastDALChange.ToString() + "', '" +
                    eventBase.Admin.UniqueID.ToString() + "', '" +
                    eventBase.ResourcePriority.ToString() + "', '" +
                    eventBase.Scalable.ToString() + "', '" +
                    eventBase.EventParent.UniqueID.ToString() + "', '" +
                    eventBase.EventLocation.UniqueID.ToString() + "', '" +
                    eventBase.Value.ToString() + "', '" +
                    eventBase.IsPublic.ToString() + "', '" +
                    eventBase.PrivacyType.ToString() + "', '" +
                    eventBase.FullImageLocation + "', '" +
                    eventBase.ThumbImageLocation + "', '" +
                    eventBase.MaxHoldings.ToString() + "');" +
                    "SELECT SCOPE_IDENTITY()");

                sqlCommand.Connection = mSqlConnection;

                eventBase.UniqueID = Convert.ToUInt64(sqlCommand.ExecuteScalar());
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

        protected void DeleteInternal(EventBase eventBase)
        {
            try
            {
                eventBase.LastDALChange = DateTime.Now.Ticks;

                SqlCommand sqlCommand = new SqlCommand("delete from EventBase where " +
                            "UniqueID = '" + eventBase.UniqueID.ToString() + "';");

                sqlCommand.Connection = mSqlConnection;

                int lineRemoved = sqlCommand.ExecuteNonQuery();

                if (lineRemoved != 1)
                {
                    throw new System.ArgumentException("Delete from EventBase Where UniqueID=" + eventBase.UniqueID.ToString() + " failed", "UniqueID");
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

		public List<UInt64> GetEventsUniqueIDByAdminUniqueID(UInt64 adminUniqueID)
		{
			List<UInt64> uniqueIDList = new List<UInt64>();

			SqlDataReader	sqlReader = null;
			SqlCommand		sqlCommand = null;

			try
			{
				sqlCommand = new SqlCommand("select UniqueID from EventBase where AdminUniqueID = @1", mSqlConnection);
				SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
				sqlParameter.Value = adminUniqueID;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlReader = sqlCommand.ExecuteReader();
				while(sqlReader.Read())
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
            finally
            {
                mSqlConnection.Close();
            }
		}

		public List<UInt64> GetChildrenUniqueIDs(UInt64 eventParentUniqueID)
		{
			List<UInt64> uniqueIDList = new List<UInt64>();

			SqlDataReader	sqlReader = null;
			SqlCommand		sqlCommand = null;

			try
			{
				sqlCommand = new SqlCommand("select UniqueID from EventBase where EventParentUniqueID = @1", mSqlConnection);
				SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
				sqlParameter.Value = eventParentUniqueID;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlReader = sqlCommand.ExecuteReader();
				while(sqlReader.Read())
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
            finally
            {
                mSqlConnection.Close();
            }
		}
	}
}
