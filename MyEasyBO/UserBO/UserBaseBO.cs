using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyObjects.User;
using MyEasyDAL.User;
using MyEasyObjects.Holding;
using MyEasy.Common;
using MyEasyBO.Object;
using MyEasyBO.HoldingBO;
using MyEasyBO.ResourceBO;
using MyEasyBO.Event;
using MyEasyObjects.Event;
//using MyEasyBO.HoldingBO;
//using MyEasyBO.ResourceBO;

namespace MyEasyBO.UserBO
{
	public class UserBaseBO
	{
		#region Members

		UserBaseDAL			mUserBaseDAL	= new UserBaseDAL();
		ObjectLocationBO	mObjectLocationBO = new ObjectLocationBO();

		EventBaseBO			mEventBaseBO	= new EventBaseBO();

		#endregion

		public void ClearValues(UserBase userBase)
		{

			userBase.UniqueID = 0;

			userBase.FirstName	= "";
			userBase.LastName	= "";
			userBase.Email		= "";
			userBase.Phone		= "";
			userBase.Gender		= EGender.eGenderNull;
			userBase.Title		= ETitle.eTitleNull;
			mObjectLocationBO.ClearValues(userBase.Location);

			userBase.HoldingsInfo.Clear();

			userBase.Events.Clear();
		}

		// Exceptions:
		//	System.ArgumentException:
		//		HoldingInfo already exists
		public void AddHoldingInfo(UserBase userBase, HoldingsInfo holdingInfo)
		{
			if (userBase.HoldingsInfo.Contains(holdingInfo))
			{
		        throw new System.ArgumentException("ParticpantInfo already exists", "holdingInfo");
			}

			userBase.HoldingsInfo.Add(holdingInfo);

			userBase.OnPropertyChanged("UserBase.HoldingsInfo.Changed");
		}

		// Exceptions:
		//	System.ArgumentException:
		//		ParticpantInfo not found
		//		Could not remove ParticpantInfo
		public void RemoveHoldingInfo(UserBase userBase, HoldingsInfo holdingInfo)
		{
			if (!userBase.HoldingsInfo.Contains(holdingInfo))
			{
		        throw new System.ArgumentException("ParticpantInfo not found", "holdingInfo");
			}

			userBase.HoldingsInfo.Remove(holdingInfo);

			if (userBase.HoldingsInfo.Contains(holdingInfo))
			{
		        throw new System.ArgumentException("Could not remove ParticpantInfo", "holdingInfo");
			}

			userBase.OnPropertyChanged("UserBase.HoldingsInfo.Changed");
		}

		public void Save(UserBase userBase)
		{
			mObjectLocationBO.Save(userBase.Location);

			mUserBaseDAL.Save(userBase);

			/*for(int i = 0; i < userBase.HoldingsInfo.Count; i++)
				mHoldingsInfoBO.Save(userBase.HoldingsInfo[i]);

			for(int i = 0; i < userBase.Resources.Count; i++)
				mResourceBaseBO.Save(userBase.Resources[i]);*/
		}

        public bool UserExists(UInt64 uniqueID)
        {
            return mUserBaseDAL.UserBaseExists(uniqueID);
        }

		// Exceptions:
		//	System.ArgumentException:
		//		userBase is null when loading UserBase
		//		Load Failed
		public void Load(UserBase userBase, bool loadLocation = true, bool loadChildren = true)
		{
			try
			{
				if(userBase.IsNull)
				{
					throw new System.ArgumentException("userBase is null when loading UserBase", "userBase");
				}

                LoadInternal(userBase, loadLocation, loadChildren);
			}
			catch
			{
				throw new System.ArgumentException("Load Failed", "userBase");
			}
		}

		// Exceptions:
		//	System.ArgumentException:
		//		Load Failed
        protected void LoadInternal(UserBase userBase, bool loadLocation, bool loadChildren)
		{
			try
			{
                mUserBaseDAL.Load(userBase, userBase.UniqueID);

                if (loadLocation)
                {
                    mObjectLocationBO.Load(userBase.Location);
                }

                if (loadChildren)
                {
                    userBase.Events.Clear();

                    List<UInt64> eventsUniqueIDs = mEventBaseBO.GetEventsUniqueIDByAdminUniqueID(userBase.UniqueID);
                    foreach (UInt64 eventUniqueID in eventsUniqueIDs)
                    {
                        userBase.Events.Add(new EventBase(eventUniqueID));
                    }

                    eventsUniqueIDs = mEventBaseBO.GetEventsUniqueIDByHolderUniqueID(userBase.UniqueID);
                    foreach (UInt64 eventUniqueID in eventsUniqueIDs)
                    {
                        userBase.Events.Add(new EventBase(eventUniqueID));
                    }
                }
			}
			catch
			{
				throw new System.ArgumentException("Load Failed", "userBase");
			}
		}

		public bool IsLatest(UserBase userBase)
		{
			return mUserBaseDAL.IsLatest(userBase);
		}

		public void GetLatest(UserBase userBase)
		{
			if(!IsLatest(userBase))
				Load(userBase);
		}
	}
}
