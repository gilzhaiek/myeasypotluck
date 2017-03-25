using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using MyEasy.Common;
using System.IO;
using System.Data.SqlTypes;

namespace MyEasyObjects.Event
{
	public class EventTimeInfo : MyObjectBase, INotifyPropertyChanged
	{
		#region Members

		DateTime?	mCreationTime	= null;
		DateTime?	mBecomeActive	= null;
		DateTime?	mBecomeInactive = null;

		#endregion

		#region Constructor
		
		public EventTimeInfo()
		{
		}

		public EventTimeInfo(UInt64 uniqueID)
			: base(uniqueID)
		{
		}

		public EventTimeInfo(UInt64 uniqueID, DateTime? creationTime)
			: base(uniqueID)
		{
			mCreationTime	= creationTime;
		}

		public EventTimeInfo(UInt64 uniqueID, DateTime? creationTime, DateTime? becomeActive, DateTime? becomeInactive)
			: base(uniqueID)
		{
			mCreationTime	= creationTime;
			mBecomeActive	= becomeActive;
			mBecomeInactive	= becomeInactive;
		}

		#endregion

		#region Properties
		public UInt64 EventUniqueID
		{
			get {return UniqueID;}
			set {UniqueID = value;}
		}

		public DateTime? CreationTime
		{
			get { return mCreationTime; }
			set
			{
				if(mCreationTime == null)
				{
					mCreationTime = value;
					OnPropertyChanged("EventTimeInfo.CreationTime.Changed");
				}
				else if(mCreationTime.Value != value.Value)
				{
					mCreationTime = value;
					OnPropertyChanged("EventTimeInfo.CreationTime.Changed");
				}
			}
		}

		public DateTime? BecomeActive
		{
			get { return mBecomeActive; }
			set
			{
				if(mBecomeActive == null)
				{
					mBecomeActive = value;
					OnPropertyChanged("EventTimeInfo.BecomeActive.Changed");
				}
				else if(mBecomeActive.Value != value.Value)
				{
					mBecomeActive = value;
					OnPropertyChanged("EventTimeInfo.BecomeActive.Changed");
				}
			}
		}

		public DateTime? BecomeInactive
		{
			get { return mBecomeInactive; }
			set
			{
				if(mBecomeInactive == null)
				{
					mBecomeInactive = value;
					OnPropertyChanged("EventTimeInfo.BecomeInactive.Changed");
				}
				else if(mBecomeInactive.Value != value.Value)
				{
					mBecomeInactive = value;
					OnPropertyChanged("EventTimeInfo.BecomeInactive.Changed");
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

				if(CreationTime != null)
					retStr += mDelim + CreationTime.Value.Ticks.ToString();
				else
					retStr += mDelim + "0";

				if(BecomeActive != null)
					retStr += mDelim + BecomeActive.Value.Ticks.ToString();
				else
					retStr += mDelim + "0";

				if(BecomeInactive != null)
					retStr += mDelim + BecomeInactive.Value.Ticks.ToString();
				else
					retStr += mDelim + "0";

				return retStr;
			}
		}
		
		public static EventTimeInfo Parse(SqlString sqlStr)
		{
			if (sqlStr.IsNull)
				return null;
			else
			{
				return Parse(Convert.ToString(sqlStr));
			}
		}

		public static EventTimeInfo Parse(string str)
		{
			int strCnt = 0;

			EventTimeInfo eventTimeInfo = new EventTimeInfo();
			
			string[] strSplit = null;
			strSplit = str.Split(new char[] { ';' });

			strCnt = Parse(eventTimeInfo, strSplit, strCnt);

			return eventTimeInfo;
		}
		
		public static int Parse(EventTimeInfo eventTimeInfo, string[] strSplit, int strCnt)
		{
			eventTimeInfo.UniqueID			= Convert.ToUInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

			eventTimeInfo.CreationTime		= new DateTime(Convert.ToInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt])); strCnt++;
			
			eventTimeInfo.BecomeActive		= new DateTime(Convert.ToInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt])); strCnt++;
			
			eventTimeInfo.BecomeInactive		= new DateTime(Convert.ToInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt])); strCnt++;

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

			EventTimeInfo eventTimeInfo = other as EventTimeInfo;

			if (eventTimeInfo == null)
				throw new System.ArgumentException("The argument to compare is not a eventTimeInfo", "other");

			if(IsNull)// || (!IsLoaded()))
				throw new System.ArgumentException("Refering object (this) is null", "this");

			return this.ToString().CompareTo(eventTimeInfo.ToString());
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
