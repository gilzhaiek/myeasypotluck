using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasy.Common;
using System.ComponentModel;
using System.Data.SqlTypes;

namespace MyEasyObjects.Object
{
	public class UserNameImageList : MyObjectBase, INotifyPropertyChanged
	{
		#region Members

		List <NameImage> mItems;

		#endregion

		public UserNameImageList()
		{
			mItems = new List<NameImage>();
		}

		public UserNameImageList(UInt64 uniqueID)
			: base(uniqueID)
		{
			mItems = new List<NameImage>();
		}

		public List <NameImage> Items
		{
			get {return mItems;}
			set {mItems = value;}
		}

		#region String Conversion Members

		public override string ToString()
		{
			if (IsNull)
				throw new System.ArgumentException("ToString failed, this is null or not loaded", "this");
			else
			{
				string retStr = UniqueID.ToString();

				retStr += mDelim + Items.Count.ToString();
				for(int i = 0; i < Items.Count; i++)
				{
					retStr += mDelim + Items[i].Name;
					retStr += mDelim + Items[i].ImageLocation;
				}

				return retStr;
			}
		}
		
		public static UserNameImageList Parse(SqlString sqlStr)
		{
			if (sqlStr.IsNull)
				return null;
			else
			{
				return Parse(Convert.ToString(sqlStr));
			}
		}

		public static UserNameImageList Parse(string str)
		{
			int strCnt = 0;
			int count = 0;

			UserNameImageList userNameImageList = new UserNameImageList();

			string[] strSplit = null;
			strSplit = str.Split(new char[] { ';' });

			userNameImageList.UniqueID	= Convert.ToUInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

			count = Convert.ToInt32(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;
			for(int i = 0; i < count; i++)
			{
				if(strSplit[strCnt] == null)
					break;
				userNameImageList.Items.Add(new NameImage(strSplit[strCnt], strSplit[strCnt+1])); strCnt++; strCnt++;
			}

			return userNameImageList;
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
		//		The argument to compare is not a UserNameImageList
		//		Refering object (this) is null
		public override int CompareTo(object other)
		{
			if (other == null)
				throw new System.ArgumentException("Other object is null", "other");

			UserNameImageList userNameImageList = other as UserNameImageList;

			if (userNameImageList == null)
				throw new System.ArgumentException("The argument to compare is not a UserNameImageList", "other");

			if(IsNull)// || (!IsLoaded()))
				throw new System.ArgumentException("Refering object (this) is null", "this");

			return this.ToString().CompareTo(userNameImageList.ToString());
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
