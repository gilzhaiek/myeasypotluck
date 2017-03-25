using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasy.Common;
using System.ComponentModel;
using MyEasyObjects.Resource;
using MyEasyObjects.User;
using System.Data.SqlTypes;
using MyEasyObjects.Event;

namespace MyEasyObjects.Item
{
	public class ItemBase : ResourceBase
    {
        #region Members

		EventBase			mEventParent	= null;

		ItemBase			mItemParent		= null; 

		List<ItemBase>		mItemChildren	= new List<ItemBase>();	
        
        #endregion 

        #region Constructor

		public ItemBase() :
			base(
				0,
				new UserBase(),
				new ResourceDescription())
		{
            MaxHoldings = 1;  // Default max holdings for Admin
		}

		public ItemBase(UInt64 uniqueID) :
			base(
				uniqueID,
				new UserBase(),
				new ResourceDescription(uniqueID))
		{
			mEventParent = new EventBase();
        }

		public ItemBase(UInt64 uniqueID, EventBase eventParent) :
			base(
				uniqueID,
				new UserBase(),
				new ResourceDescription(uniqueID))
		{
			mEventParent = eventParent;
        }

		public ItemBase(UInt64 uniqueID, EventBase eventParent, UserBase adminUser) :
			base(
				uniqueID,
				adminUser,
				new ResourceDescription(uniqueID))
		{
			mEventParent = eventParent;
        }

        public ItemBase(UInt64 uniqueID, EventBase eventParent, UserBase adminUser, NameImage nameImage) :
			base(
				uniqueID,
				adminUser,
				new ResourceDescription(uniqueID),
                nameImage,
                new NameImage())
		{
			mEventParent = eventParent;
		}

        #endregion

		#region properties
		public override UInt64 UniqueID
		{
			get { return mUniqueID; }
			set
			{
				if (mUniqueID != value)
				{
					mUniqueID							= value;
					mResourceDescription.OwnerUniqueID	= value;
					OnPropertyChanged("ItemBase.UniqueID.Changed");
				}
			}
		}
		
		public EventBase EventParent
		{
			get { return mEventParent; }
			set 
			{
				if(mEventParent != value)
				{
					mEventParent = value;
					EventParentChanged();
				}
			}
		}

		public ItemBase ItemParent
		{
			get
			{
				if(mItemParent == null)
				{
					mItemParent = new ItemBase();
				}
				
				return mItemParent;
			}
			set 
			{
				if(mItemParent != value)
				{
					mItemParent = value;
					ItemParentChanged();
				}
			}
		}

		public List<ItemBase> ItemChildren
		{
			get { return mItemChildren; }
		}

        public string Name
        {
            get { return ThumbName; }
            set { ThumbName = value;}
        }

        public string ImageLocation
        {
            get { return FullImageLocation; }
            set { FullImageLocation = value; }
        }

        public NameImage NameImage
        {
            get { return ThumbNameImage; }
            set { ThumbNameImage = value; }
        }
        
        #endregion

		#region String Conversion Members

		public override string ToString()
		{
			if (IsNull)
				throw new System.ArgumentException("ToString failed, this is null or not loaded", "this");
			else
			{
				string retStr = base.ToString();

				if(EventParent == null)
					retStr += mDelim + "0";
				else
					retStr += mDelim + EventParent.UniqueID.ToString();

				if(ItemParent == null)
					retStr += mDelim + "0";
				else
					retStr += mDelim + ItemParent.UniqueID.ToString();

				retStr += mDelim + ItemChildren.Count.ToString();
				for(int i = 0; i < ItemChildren.Count; i++)
					retStr += mDelim + ItemChildren[i].UniqueID.ToString();
        
				return retStr;
			}
		}

		public static ItemBase Parse(string str)
		{
			int strCnt = 0;

			ItemBase itemBase = new ItemBase();

			string[] strSplit = null;
			strSplit = str.Split(new char[] { ';' });

			strCnt = ResourceBaseParse((ResourceBase)itemBase, strSplit, strCnt);

			strCnt = Parse(itemBase, strSplit, strCnt);

			return itemBase;
		}
		
		public static int Parse(ItemBase itemBase, string[] strSplit, int strCnt)
		{
			int count = 0;

			UInt64 eventParentUniqueID = Convert.ToUInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;
			if(eventParentUniqueID != 0)
				itemBase.EventParent = new EventBase(eventParentUniqueID);

			UInt64 itemParentUniqueID = Convert.ToUInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;
			if(itemParentUniqueID != 0)
				itemBase.ItemParent = new ItemBase(itemParentUniqueID);

			count = Convert.ToInt32(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;
			for(int i = 0; i < count; i++)
			{
				if(strSplit[strCnt] == null)
					break;
				itemBase.ItemChildren.Add(new ItemBase(Convert.ToUInt64(strSplit[strCnt]))); strCnt++;
			}

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
		//		The argument to compare is not a ItemBase
		//		Refering object (this) is null
		public override int CompareTo(object other)
		{
			if (other == null)
				throw new System.ArgumentException("Other object is null", "other");

			ItemBase itemBase = other as ItemBase;

			if (itemBase == null)
				throw new System.ArgumentException("The argument to compare is not an ItemBase", "other");

			if(IsNull)// || (!IsLoaded()))
				throw new System.ArgumentException("Refering object (this) is null", "this");

			return this.ToString().CompareTo(itemBase.ToString());
		}

		#endregion

		#region INotifyPropertyChanged Members

		private void EventParentChanged()		{ OnPropertyChanged("ItemBase.EventParent.Changed"); }

		private void ItemParentChanged()		{ OnPropertyChanged("ItemBase.ItemParent.Changed"); }
		
	    #endregion
    }
}
