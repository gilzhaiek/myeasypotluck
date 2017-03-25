using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasy.Common;
using MyEasyObjects.Resource;
using MyEasyObjects.User;
using System.ComponentModel;
using System.IO;
using System.Data.SqlTypes;
using MyEasyObjects.Event;
using MyEasyObjects.Item;

namespace MyEasyObjects.Holding
{
	public class UserPermission
	{
		#region Members
		 
		UInt64					mHoldingInfoUniqueID;
		UserBase				mUserBase;
		EHoldingPermissions		mHoldingPermission;

		#endregion
		
		public UserPermission()
		{
			mHoldingInfoUniqueID	= 0;
			mUserBase				= null;
			mHoldingPermission		= EHoldingPermissions.eHoldingPermissionsNull;
		}

		public UserPermission(UInt64 holdingInfoUniqueID)
		{
			mHoldingInfoUniqueID	= holdingInfoUniqueID;
			mUserBase				= null;
			mHoldingPermission		= EHoldingPermissions.eHoldingPermissionsNull;
		}

		public UserPermission(UInt64 holdingInfoUniqueID, UserBase userBase, EHoldingPermissions holdingPermission)
		{
			mHoldingInfoUniqueID	= holdingInfoUniqueID;
			mUserBase				= userBase;
			mHoldingPermission		= holdingPermission;
		}

		#region Properties

		public UInt64				HoldingInfoUniqueID
		{
			get {return mHoldingInfoUniqueID;}
			set {mHoldingInfoUniqueID = value;}
		}

		public UserBase				UserBase
		{
			get {return mUserBase;}
			set {mUserBase = value;}
		}

		public EHoldingPermissions	HoldingPermission
		{
			get {return mHoldingPermission;}
			set {mHoldingPermission = value;}
		}

		#endregion
	}

	public class HoldingsInfo : MyObjectBase, INotifyPropertyChanged
	{
		#region Members

		UserBase				mHoldingUser		= null;

		EHoldingPermissions		mHoldingUserPermission = EHoldingPermissions.eHoldingPermissionsNull;

		EventBase				mEventOwner			= null;
		
		ItemBase				mItemOwner			= null;

		List<UserPermission>	mUserPermissions	= new List<UserPermission>();

		List<int>				mHoldingTypes		= new List<int>();

		bool					mAllowOverBooking	= false;

		bool					mScalable			= false;

		bool					mNeedsOwnerApprovel	= false;

		EHoldingApprovel		mHoldingApprovel	= EHoldingApprovel.eHoldingApprovelNull;  // Incase mNeedsOwnerApprovel is true


		#endregion

		#region Consturctor

		public HoldingsInfo()
		{
			mHoldingUser = new UserBase();
			mEventOwner = new EventBase();
			mItemOwner	= new ItemBase();
		}

        public HoldingsInfo(UserBase holdingUser)
        {
            mHoldingUser = holdingUser;
            mEventOwner = new EventBase();
            mItemOwner = new ItemBase();
        }

        public HoldingsInfo(UserBase holdingUser, ItemBase itemBase)
        {
            mHoldingUser = holdingUser;
            mEventOwner = new EventBase(itemBase.EventParent.UniqueID);
            mItemOwner = itemBase;
        }

		public HoldingsInfo(UInt64 uniqueID)
			: base(uniqueID)
		{
			mHoldingUser = new UserBase();
			mEventOwner = new EventBase();
			mItemOwner	= new ItemBase();
		}

		public HoldingsInfo(UInt64 uniqueID, EventBase eventBase, ItemBase itemBase)
			: base(uniqueID)
		{
			mHoldingUser	= new UserBase();
			mEventOwner		= eventBase;
			mItemOwner		= itemBase;
		}

		#endregion

		#region Properties
		public override UInt64 UniqueID
		{
			get
			{
				return base.UniqueID;
			}
			set
			{
				foreach(UserPermission userPermission in mUserPermissions)
				{
					userPermission.HoldingInfoUniqueID = value;
				}

				base.UniqueID = value;
			}
		}

		public UserBase	HoldingUser
		{
			get
			{
				if(mHoldingUser == null)
					mHoldingUser = new UserBase();
				return mHoldingUser;
			}
			set 
			{
				if (mHoldingUser != value)
				{
					mHoldingUser = value;
					OnPropertyChanged("HoldingsInfo.HoldingUser.Changed");
				}
			}
		}

		public EHoldingPermissions HoldingUserPermissions
		{
			get { return mHoldingUserPermission;}
			set
			{
				if (mHoldingUserPermission != value)
				{
					mHoldingUserPermission = value;
					OnPropertyChanged("HoldingsInfo.HoldingUserPermission.Changed");
				}
			}
		}

		public EventBase EventOwner
		{
			get { return mEventOwner;}
			set
			{
				if (mEventOwner != value)
				{
					mEventOwner = value;
					OnPropertyChanged("HoldingsInfo.EventOwner.Changed");
				}
			}
		}

		public ItemBase ItemOwner
		{
			get
			{
				if(mItemOwner == null)
					mItemOwner = new ItemBase();

				return mItemOwner;
			}
			set
			{
				if (mItemOwner != value)
				{
					mItemOwner = value;
					OnPropertyChanged("HoldingsInfo.ItemOwner.Changed");
				}
			}
		}

		public List<UserPermission>		UserPermissions
		{
			get {return mUserPermissions;}
		}

		public List<int> HoldingTypes
		{
			get { return mHoldingTypes; }
			set
			{
				if (mHoldingTypes != value)
				{
					mHoldingTypes = value;
					OnPropertyChanged("HoldingsInfo.HoldingTypes.Changed");
				}
			}
		}

		public bool AllowOverBooking
		{
			get { return mAllowOverBooking; }
			set
			{
				if (mAllowOverBooking != value)
				{
					mAllowOverBooking = value;
					OnPropertyChanged("HoldingsInfo.AllowOverBooking.Changed");
				}
			}
		}

		public bool Scalable
		{
			get { return mScalable; }
			set
			{
				if (mScalable != value)
				{
					mScalable = value;
					OnPropertyChanged("HoldingsInfo.Scalable.Changed");
				}
			}
		}

		public bool NeedsOwnerApprovel
		{
			get { return mNeedsOwnerApprovel; }
			set
			{
				if (mNeedsOwnerApprovel != value)
				{
					mNeedsOwnerApprovel = value;
					OnPropertyChanged("HoldingsInfo.NeedsOwnerApprovel.Changed");
				}
			}
		}

		public EHoldingApprovel HoldingApprovel
		{
			get { return mHoldingApprovel; }
			set
			{
				if (mHoldingApprovel != value)
				{
					mHoldingApprovel = value;
					OnPropertyChanged("HoldingsInfo.HoldingApprovel.Changed");
				}
			}
		}

		#endregion

		#region String Conversion Members

		public override string ToString()
		{
			if (IsNull)// || (!IsLoaded()))
				throw new System.ArgumentException("ToString failed, this is null or not loaded", "this");
			else
			{
				string retStr = UniqueID.ToString();

				if(HoldingUser == null)
					retStr += mDelim + "0";
				else
					retStr += mDelim + HoldingUser.UniqueID.ToString();

				if(EventOwner == null)
					retStr += mDelim + "0";
				else
					retStr += mDelim + EventOwner.UniqueID.ToString();

				if(ItemOwner == null)
					retStr += mDelim + "0";
				else
					retStr += mDelim + ItemOwner.UniqueID.ToString();

				retStr += mDelim + UserPermissions.Count.ToString();
				for(int i = 0; i < UserPermissions.Count; i++)
				{
					retStr += mDelim + UserPermissions[i].UserBase.UniqueID.ToString();
					retStr += mDelim + ((int)UserPermissions[i].HoldingPermission).ToString();
				}

				retStr += mDelim + HoldingTypes.Count.ToString();
				for(int i = 0; i < HoldingTypes.Count; i++)
					retStr += mDelim + HoldingTypes[i].ToString();	
	
				retStr += mDelim + AllowOverBooking.ToString();

				retStr += mDelim + Scalable.ToString();

				retStr += mDelim + NeedsOwnerApprovel.ToString();

				retStr += mDelim + ((int)HoldingApprovel).ToString();

				return retStr;
			}
		}
		
		public static HoldingsInfo Parse(SqlString sqlStr)
		{
			if (sqlStr.IsNull)
				return null;
			else
			{
				return Parse(Convert.ToString(sqlStr));
			}
		}

		public static HoldingsInfo Parse(string str)
		{
			int strCnt = 0;

			HoldingsInfo holdingsInfo = new HoldingsInfo();

			string[] strSplit = null;
			strSplit = str.Split(new char[] { ';' });

			strCnt = Parse(holdingsInfo, strSplit, strCnt);

			return holdingsInfo;
		}
		
		public static int Parse(HoldingsInfo holdingsInfo, string[] strSplit, int strCnt)
		{
			int count = 0;

			holdingsInfo.UniqueID	= Convert.ToUInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

			holdingsInfo.HoldingUser.UniqueID	= Convert.ToUInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

			holdingsInfo.EventOwner.UniqueID	= Convert.ToUInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

			holdingsInfo.ItemOwner.UniqueID	= Convert.ToUInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

			count = Convert.ToInt32(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;
			for(int i = 0; i < count; i++)
			{
				if(strSplit[strCnt] == null)
					break;

				UserPermission userPermission = new UserPermission(
					holdingsInfo.UniqueID,
					new UserBase(Convert.ToUInt64(strSplit[strCnt++])),
					(EHoldingPermissions)Convert.ToInt32(strSplit[strCnt++]));

				holdingsInfo.UserPermissions.Add(userPermission);
			}
			
			count = Convert.ToInt32(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;
			for(int i = 0; i < count; i++)
			{
				if(strSplit[strCnt] == null)
					break;
				holdingsInfo.HoldingTypes.Add(Convert.ToInt32(strSplit[strCnt])); strCnt++;
			}

			holdingsInfo.AllowOverBooking		= Convert.ToBoolean(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

			holdingsInfo.Scalable				= Convert.ToBoolean(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

			holdingsInfo.NeedsOwnerApprovel		= Convert.ToBoolean(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

			holdingsInfo.HoldingApprovel	= (EHoldingApprovel)Convert.ToInt32(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

			return strCnt;
		}

		#endregion

		
		#region IComparable Members

		//Override the Equals method        
		public override bool Equals(object other)
		{
			return CompareTo(other) == 0;
		}

		//Override the GetHashCode method
		public override int GetHashCode()
		{
			if(IsNull)// || (!IsLoaded()))
				return 0;

			return this.ToString().GetHashCode();
		}

		// Exceptions:
		//	System.ArgumentException:
		//		Other object is null
		//		The argument to compare is not a UserBase
		//		Refering object (this) is null
		public override int CompareTo(object other)
		{
			if (other == null)
				throw new System.ArgumentException("Other object is null", "other");

			HoldingsInfo holdingsInfo = other as HoldingsInfo;

			if (holdingsInfo == null)
				throw new System.ArgumentException("The argument to compare is not a holdingsInfo", "other");

			if(IsNull)// || (!IsLoaded()))
				throw new System.ArgumentException("Refering object (this) is null", "this");

			return this.ToString().CompareTo(holdingsInfo.ToString());
		}

		#endregion

		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = this.PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion
	}
}
