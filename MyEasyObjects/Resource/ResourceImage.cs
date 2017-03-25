using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyObjects.User;
using MyEasyObjects.Resource;
using MyEasy.Common;
using System.IO;
using System.Data.SqlTypes;
using System.ComponentModel;

namespace MyEasyObjects.Resource
{
	public class ResourceImage : MyObjectBase, INotifyPropertyChanged
	{
		#region Members

		UserBase			mImageOwner;

		ResourceBase		mResourceBase;

		string				mImageLocation	= ""; 
		
		DateTime?			mEntryDate		= null;

		#endregion

		#region constructor

		public ResourceImage()
		{
			mResourceBase	= new ResourceBase();
			mImageOwner		= new UserBase();
		}

		public ResourceImage(UInt64 uniqueID)
			: base(uniqueID)
		{
			mResourceBase	= new ResourceBase();
			mImageOwner		= new UserBase();
		}


		public ResourceImage(UInt64 uniqueID, UserBase imageOwner, string imageLocation, DateTime? entryDate)
			: base(uniqueID)
		{
			mResourceBase	= new ResourceBase();
			mImageOwner		= imageOwner;
			mImageLocation	= imageLocation;
			mEntryDate		= entryDate;
		}

		public ResourceImage(UInt64 uniqueID, UserBase imageOwner, string imageLocation, DateTime? entryDate, ResourceBase resourceBase)
			: base(uniqueID)
		{
			mResourceBase	= resourceBase;
			mImageOwner		= imageOwner;
			mImageLocation	= imageLocation;
			mEntryDate		= entryDate;
		}	

		#endregion

		public ResourceBase	ResourceBase
		{
			get {return mResourceBase;}
			set { mResourceBase = value;}
		}

		public UserBase		ImageOwner
		{ 
			get { return mImageOwner; }
			set { ImageOwner = value;}
		}

		public string		ImageLocation
		{	
			get { return mImageLocation; } 
			set { mImageLocation = value;}
		}

		public DateTime?		EntryDate
		{
			get { return mEntryDate; }
			set { EntryDate = value;}
		}

		#region String Conversion Members

		public override string ToString()
		{
			if (IsNull)// || (!IsLoaded()))
				throw new System.ArgumentException("ToString failed, this is null or not loaded", "this");
			else
			{
				string retStr = UniqueID.ToString();

				retStr += mDelim + ImageOwner.UniqueID.ToString();

				retStr += mDelim + ResourceBase.UniqueID.ToString();

				retStr += mDelim + ImageLocation;

				if(EntryDate != null)
					retStr += mDelim + EntryDate.Value.Ticks.ToString();
				else
					retStr += mDelim + "0";

				return retStr ;
			}
		}
		
		public static ResourceImage Parse(SqlString sqlStr)
		{
			if (sqlStr.IsNull)
				return null;
			else
			{
				return Parse(Convert.ToString(sqlStr));
			}
		}

		public static ResourceImage Parse(string str)
		{
			int strCnt = 0;

			ResourceImage image = new ResourceImage();
			
			string[] strSplit = null;
			strSplit = str.Split(new char[] { ';' });

			strCnt = Parse(image, strSplit, strCnt);

			return image;
		}
		
		public static int Parse(ResourceImage image, string[] strSplit, int strCnt)
		{
			image.UniqueID				= Convert.ToUInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

			image.ImageOwner.UniqueID	= Convert.ToUInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

			image.ResourceBase.UniqueID	= Convert.ToUInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

			image.ImageLocation			= strSplit[strCnt]; strCnt++;

			image.EntryDate				= new DateTime(Convert.ToInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt])); strCnt++;

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

			ResourceImage resourceImage = other as ResourceImage;

			if (resourceImage == null)
				throw new System.ArgumentException("The argument to compare is not a resourceImage", "other");

			if(IsNull)// || (!IsLoaded()))
				throw new System.ArgumentException("Refering object (this) is null", "this");

			return this.ToString().CompareTo(resourceImage.ToString());
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
