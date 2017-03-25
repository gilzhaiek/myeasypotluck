using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MyEasy.Common
{
	public class NameImage : IComparable
	{
		protected string mDelim = new string((new char[] { ';' }));

		UInt64		mUniqueID		= 0;
		string		mName			= "";
		string		mImageLocation	= "";
		bool		mIsDefault		= true;
		int			mValue			= 0;

		public NameImage()
		{
		}

		public NameImage(string name, string imageLocation)
		{
			Name			= name;
			ImageLocation	= imageLocation;
		}


		public NameImage(string name, string imageLocation, int value)
		{
			Name			= name;
			ImageLocation	= imageLocation;
			Value			= value;
		}

		public string Name
		{
			get {return mName;}
			set {mName = value;}
		}

		public string ImageLocation
		{
			get {return mImageLocation;}
			set {mImageLocation = value;}
		}

		public int Value
		{
			get {return mValue;}
			set {mValue = value;}
		}


		public bool IsDefault
		{
			get {return mIsDefault;}
			set {mIsDefault = value;}
		}

		public override string ToString()
		{
			string retStr = mName;

			retStr += mDelim;

			retStr += ImageLocation;

			return retStr;
		}

		public static NameImage Parse(string str)
		{
			int strCnt = 0;
			NameImage nameImage = null;
			
			string[] strSplit = null;
			strSplit = str.Split(new char[] { ';' });

			strCnt = Parse(nameImage, strSplit, strCnt);

			return nameImage;
		}
		
		public static int Parse(NameImage nameImage, string[] strSplit, int strCnt)
		{
			nameImage.Name			= strSplit[strCnt] == null ? "" : strSplit[strCnt]; strCnt++;
			nameImage.ImageLocation	= strSplit[strCnt] == null ? "" : strSplit[strCnt]; strCnt++;

			return strCnt;
		}

		public int CompareTo(object obj)
		{
			if (obj == null)
				throw new System.ArgumentException("Other object is null", "obj");

			NameImage imageInfo = obj as NameImage;

			if (imageInfo == null)
				throw new System.ArgumentException("The argument to compare is not a NameImage", "imageInfo");

			return this.ToString().CompareTo(imageInfo.ToString());
		}

		public bool ImagesEqual(object obj)
		{
			if (obj == null)
				throw new System.ArgumentException("Other object is null", "obj");

			NameImage imageInfo = obj as NameImage;

			if (imageInfo == null)
				throw new System.ArgumentException("The argument to compare is not a NameImage", "imageInfo");

			return (this.ImageLocation == imageInfo.ImageLocation);
		}


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
