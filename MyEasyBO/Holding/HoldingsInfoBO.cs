using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyDAL.Holding;
using MyEasyObjects.Holding;
using MyEasyObjects.Resource;
using MyEasy.Common;
using MyEasyObjects.Item;
using MyEasyObjects.Event;
using MyEasyObjects.User;

namespace MyEasyBO.HoldingBO
{
	public class HoldingsInfoBO
	{
		#region Members

		HoldingsInfoDAL mHoldingsInfoDAL = new HoldingsInfoDAL();

		#endregion

		public void ClearValues(HoldingsInfo holdingsInfo)
		{
			holdingsInfo.UniqueID = 0;

			holdingsInfo.HoldingUser			= new UserBase();

			holdingsInfo.EventOwner				= new EventBase();

			holdingsInfo.ItemOwner				= new ItemBase();

			holdingsInfo.UserPermissions.Clear();

			holdingsInfo.HoldingTypes.Clear();

			holdingsInfo.AllowOverBooking		= false;

			holdingsInfo.Scalable				= false;

			holdingsInfo.NeedsOwnerApprovel		= false;

			holdingsInfo.HoldingApprovel	= EHoldingApprovel.eHoldingApprovelNull;  // Incase mNeedsOwnerApprovel is true

		}

		public void Save(HoldingsInfo holdingsInfo)
		{
			mHoldingsInfoDAL.Save(holdingsInfo);
		}

		public void Delete(HoldingsInfo holdingsInfo)
		{
            if (!holdingsInfo.IsLoaded())
                Load(holdingsInfo);

			mHoldingsInfoDAL.Delete(holdingsInfo);
		}

		// Exceptions:
		//	System.ArgumentException:
		//		holdingsInfo is null when loading HoldingsInfo
		//		Load Failed
		public void Load(HoldingsInfo holdingsInfo)
		{
			try
			{
				if(holdingsInfo.IsNull)
				{
					throw new System.ArgumentException("holdingsInfo is null when loading HoldingsInfo", "holdingsInfo");
				}				

				Load(holdingsInfo, holdingsInfo.UniqueID);
			}
			catch
			{
				throw new System.ArgumentException("Load Failed", "holdingsInfo");
			}
		}

		// Exceptions:
		//	System.ArgumentException:
		//		Load Failed
		public void Load(HoldingsInfo holdingsInfo, UInt64 uniqueID)
		{
			try
			{
				mHoldingsInfoDAL.Load(holdingsInfo, uniqueID);
			}
			catch
			{
				throw new System.ArgumentException("Load Failed", "holdingsInfo");
			}
		}

		public List<UInt64> GetUniqueIDsByEventOwner(UInt64 eventOwnerUniqueID)
		{
			try
			{
				return mHoldingsInfoDAL.GetUniqueIDsByEventOwner(eventOwnerUniqueID);
			}
			catch
			{
				throw new System.ArgumentException("GetUniqueIDsByEventOwner Failed", "eventOwnerUniqueID");
			}
		}

		public List<UInt64> GetEventsUniqueIDByHolderUniqueID(UInt64 holdingUserUniqueID)
		{
			try
			{
				return mHoldingsInfoDAL.GetEventsUniqueIDByHolderUniqueID(holdingUserUniqueID);
			}
			catch
			{
				throw new System.ArgumentException("GetEventsUniqueIDByHolderUniqueID Failed", "holderUniqueID");
			}
		}

		public List<UInt64> GetUniqueIDsByItemOwner(UInt64 itemOwnerUniqueID)
		{
			try
			{
				return mHoldingsInfoDAL.GetUniqueIDsByItemOwner(itemOwnerUniqueID);
			}
			catch
			{
				throw new System.ArgumentException("GetUniqueIDsByItemOwner Failed", "itemOwnerUniqueID");
			}
		}
	}
}
