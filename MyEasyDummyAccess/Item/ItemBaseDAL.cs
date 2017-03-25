using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyIDAL.Item;
using MyEasyObjects.Item;
using System.Data.SqlClient;
using System.Data;
using MyEasyObjects.User;
using MyEasyObjects.Resource;
using MyEasy.Common;
using MyEasyObjects.Event;

namespace MyEasyDAL.Item
{
	public class ItemBaseDAL : MyObjectBaseDAL, ItemBaseIDAL
	{
		#region Members
		#endregion

		public ItemBaseDAL()
		{
		}

		public bool IsLatest(ItemBase itemBase, bool checkRelations)
		{
			ItemBase upToDateItemBase = new ItemBase();

			Load(upToDateItemBase, itemBase.UniqueID);

			if(upToDateItemBase.LastDALChange != itemBase.LastDALChange)
				return false;
			
			if(checkRelations)
			{
				foreach(ItemBase itemChild in itemBase.ItemChildren)
				{
					if(!IsLatest(itemChild, false))
						return false;
				}
			}

			return true;
		}

		// Exceptions:
		//	System.ArgumentException:
		public void	Save(ItemBase itemBase)
		{
			if(itemBase.IsNull)
			{
				SaveInternal(itemBase);
				return;
				//throw new System.ArgumentException("itemBase is null when saving ItemBase", "itemBase");
			}

			if(ItemBaseExists(itemBase.UniqueID))
			{
				ItemBase upToDateItemBase = new ItemBase();

				try
				{
					Load(upToDateItemBase, itemBase.UniqueID);
				}
				catch
				{
					SaveInternal(itemBase);
					return;
				}

				if(itemBase.CompareTo(upToDateItemBase) != 0)
					UpdateInternal(itemBase);
			}
			else
				SaveInternal(itemBase);
		}

		// Exceptions:
		//	System.ArgumentException:
		public void	Delete(ItemBase itemBase)
		{
			if(itemBase.IsNull)
			{
				throw new System.ArgumentException("itemBase is null when removing ItemBase", "itemBase");
			}

			if(ItemBaseExists(itemBase.UniqueID))
			{
				DeleteInternal(itemBase);
			}
			else
				throw new System.ArgumentException("itemBase does not exists while removing ItemBase", "itemBase");
		}

		public bool ItemBaseExists(UInt64 uniqueID)
		{
            return ObjectBaseExists(uniqueID, "ItemBase", "UniqueID");
		}

		public void Load(ItemBase itemBase, UInt64 uniqueID)
		{
			SqlDataReader	sqlReader = null;
			SqlCommand		sqlCommand = null;

			try
			{
				sqlCommand = new SqlCommand("select * from ItemBase where UniqueID = @1", mSqlConnection);
				SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
				sqlParameter.Value = uniqueID;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlReader = sqlCommand.ExecuteReader();
				if(!sqlReader.Read())
				{
					throw new System.ArgumentException("itemBase with uniqueID=" + uniqueID.ToString() + " was not found", "uniqueID");
				}
				
				itemBase.UniqueID				= uniqueID;
				itemBase.LastDALChange			= Convert.ToInt64(sqlReader["LastDALChange"].ToString());
				itemBase.Admin					= new UserBase(Convert.ToUInt64(sqlReader["AdminUniqueID"].ToString()));
				itemBase.ResourcePriority		= (EResourcePriority)Enum.Parse(typeof(EResourcePriority), sqlReader["ResourcePriority"].ToString());
				itemBase.Scalable				= Convert.ToBoolean(sqlReader["Scalable"].ToString());
				itemBase.EventParent			= new EventBase(Convert.ToUInt64(sqlReader["EventParentUniqueID"].ToString()));
				itemBase.ItemParent				= new ItemBase(Convert.ToUInt64(sqlReader["ItemParentUniqueID"].ToString()));
				itemBase.Name					= sqlReader["Name"].ToString();
                itemBase.FullImageLocation      = sqlReader["FullImageLocation"].ToString();
				itemBase.Value					= Convert.ToInt32(sqlReader["Value"].ToString());
                itemBase.MaxHoldings            = Convert.ToInt32(sqlReader["MaxHoldings"].ToString());
                itemBase.ThumbImageLocation     = sqlReader["ThumbImageLocation"].ToString();

				if(sqlReader.Read())
				{
					throw new ArgumentException("Multiple UniqueID=" + uniqueID.ToString() + " were found in ItemBase", "uniqueID");
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
		
		protected void DeleteInternal(ItemBase itemBase)
		{
			try
			{
				itemBase.LastDALChange = DateTime.Now.Ticks;

				SqlCommand sqlCommand = new SqlCommand("delete from ItemBase where " + 
							"UniqueID = '" + itemBase.UniqueID.ToString()+"';");

				sqlCommand.Connection = mSqlConnection;
				
				int lineRemoved = sqlCommand.ExecuteNonQuery();

				if(lineRemoved!= 1)
				{
					throw new System.ArgumentException("Delete from ItemBase Where UniqueID=" + itemBase.UniqueID.ToString() + " failed", "UniqueID");
				}			
			}
			catch (Exception exception)
			{
				throw exception;
			}
		}

		protected void UpdateInternal(ItemBase itemBase)
		{
			try
			{
				itemBase.LastDALChange = DateTime.Now.Ticks;

				SqlCommand sqlCommand = new SqlCommand("Update ItemBase set " +
					"LastDALChange='"			+ itemBase.LastDALChange.ToString()			+ "'," + 
					"AdminUniqueID='"			+ itemBase.Admin.UniqueID.ToString()		+ "'," + 
					"ResourcePriority='"		+ itemBase.ResourcePriority.ToString()		+ "'," + 
					"Scalable='"				+ itemBase.Scalable.ToString()				+ "'," + 
					"EventParentUniqueID='"		+ itemBase.EventParent.UniqueID.ToString()	+ "'," + 
					"ItemParentUniqueID='"		+ itemBase.ItemParent.UniqueID.ToString()	+ "'," + 
					"Name=@Name," +
                    "FullImageLocation='"       + itemBase.FullImageLocation                + "'," +
                    "Value='"                   + itemBase.Value.ToString()                 + "'," +
                    "MaxHoldings='"             + itemBase.MaxHoldings.ToString()           + "'," +
                    "ThumbImageLocation='"      + itemBase.ThumbImageLocation               + "' " +
					"Where UniqueID='"			+ itemBase.UniqueID.ToString()              + "'");

                SqlParameter sqlParameter = new SqlParameter("@Name", SqlDbType.NVarChar);
                sqlParameter.Value = itemBase.Name;
                sqlCommand.Parameters.Add(sqlParameter);

				sqlCommand.Connection = mSqlConnection;
				
				int lineInserted = sqlCommand.ExecuteNonQuery();

				if(lineInserted != 1)
				{
					throw new System.ArgumentException("Update Into ItemBase Where UniqueID=" + itemBase.UniqueID.ToString() + " failed", "UniqueID");
				}			
			}
			catch (Exception exception)
			{
				throw exception;
			}
		}

		protected void SaveInternal(ItemBase itemBase)
		{
			try
			{
				itemBase.LastDALChange = DateTime.Now.Ticks;

				SqlCommand sqlCommand = new SqlCommand("Insert Into ItemBase" +
                    " (LastDALChange, AdminUniqueID, ResourcePriority, Scalable, EventParentUniqueID, ItemParentUniqueID, Name, FullImageLocation, Value, MaxHoldings, ThumbImageLocation) values ('" +
					itemBase.LastDALChange.ToString()			+ "', '" + 
					itemBase.Admin.UniqueID.ToString()			+ "', '" + 
					itemBase.ResourcePriority.ToString()		+ "', '" + 
					itemBase.Scalable.ToString()				+ "', '" + 
					itemBase.EventParent.UniqueID.ToString()	+ "', '" + 
					itemBase.ItemParent.UniqueID.ToString()		+ "', " + 
					"@Name, '" + 
					itemBase.FullImageLocation				    + "', '" +
                    itemBase.Value.ToString()                   + "', '" +
                    itemBase.MaxHoldings.ToString()             + "', '" + 
                    itemBase.ThumbImageLocation                 + "');" + 
					"SELECT SCOPE_IDENTITY()");

                SqlParameter sqlParameter = new SqlParameter("@Name", SqlDbType.NVarChar);
                sqlParameter.Value = itemBase.Name;
                sqlCommand.Parameters.Add(sqlParameter);

				sqlCommand.Connection = mSqlConnection;
				
				itemBase.UniqueID = Convert.ToUInt64(sqlCommand.ExecuteScalar());
			}
			catch (Exception exception)
			{
				throw exception;
			}
		}

		public List<UInt64> GetChildrenUniqueIDsByEventParent(UInt64 eventParentUniqueID)
		{
			List<UInt64> uniqueIDList = new List<UInt64>();

			SqlDataReader	sqlReader = null;
			SqlCommand		sqlCommand = null;

			try
			{
				sqlCommand = new SqlCommand("select UniqueID from ItemBase where EventParentUniqueID = @1", mSqlConnection);
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
		}

		public List<UInt64> GetChildrenUniqueIDsByItemParent(UInt64 itemParentUniqueID)
		{
			List<UInt64> uniqueIDList = new List<UInt64>();

			SqlDataReader	sqlReader = null;
			SqlCommand		sqlCommand = null;

			try
			{
				sqlCommand = new SqlCommand("select UniqueID from ItemBase where ItemParentUniqueID = @1", mSqlConnection);
				SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
				sqlParameter.Value = itemParentUniqueID;
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
		}
	}
}
