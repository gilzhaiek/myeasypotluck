using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasy.Common;
using System.ComponentModel;
using System.Data.SqlTypes;
using MyEasyObjects.Event;

namespace MyEasyBO.UserBO
{
	class FriendBaseBO : INullable, IComparable, INotifyPropertyChanged
	{
        #region Members

        string		mFirstName		= "";

        string		mLastName		= "";

		string		mEmail			= "";

		EGender		mGender			= EGender.eGenderNull;

		string		mDelim = new string((new char[] { ';' }));

		EventBase	mEventBase		= null;

        #endregion

		public FriendBaseBO()
		{
			mEventBase = new EventBase();
		}

        public FriendBaseBO(string firstName, string lastName, string email, EGender gender, EventBase eventBase)
        {
			mEventBase	= eventBase;
			mFirstName	= firstName;
			mLastName	= lastName;
			mEmail		= email;
			mGender		= gender;
        }

        #region properties

		public string FirstName
        { 
            get {return mFirstName;}
            set 
            {
                if (mFirstName != value)
                {
                    mFirstName = value;
					OnPropertyChanged("FriendBaseBO.FirstName.Changed");
                }
            }
        }

        public string LastName
        {
            get { return mLastName; }
            set
            {
                if (mLastName != value)
                {
                    mLastName = value;
					OnPropertyChanged("FriendBaseBO.LastName.Changed");
                }
            }
        }

		public string Email
		{
			get { return mEmail; }
			set
			{
				// TODO - add expression check for email

				if (mEmail != value)
				{
					mEmail = value;
					OnPropertyChanged("FriendBaseBO.Email.Changed");
				}
			}
		}

		public EGender? Gender
		{
			get { return mGender; }
			set
			{
				if(value == null)
					mGender = EGender.eGenderNull;
				else if (mGender != value.Value)
				{
					mGender = value.Value;
					OnPropertyChanged("FriendBaseBO.Gender.Changed");
				}
			}
		}

        #endregion

		#region Functions

		void PropertyChangedEvent(object sender, PropertyChangedEventArgs e)
		{
		}

		#endregion


		#region String Conversion Members

		public override string ToString()
		{
			string retStr = "";

			retStr += mDelim + FirstName;
			retStr += mDelim + LastName;
			retStr += mDelim + Email;
			retStr += mDelim + ((int)Gender).ToString();

			return retStr;
		}
		
		public static FriendBaseBO Parse(SqlString sqlStr)
		{
			if (sqlStr.IsNull)
				return null;
			else
			{
				int strCnt = 0;
				int count = 0;

				FriendBaseBO friendBase = new FriendBaseBO();

				string str = Convert.ToString(sqlStr);
				string[] strSplit = null;
				strSplit = str.Split(new char[] { ';' });

				
				friendBase.FirstName	= strSplit[strCnt] == null ? "" : strSplit[strCnt]; strCnt++;
				friendBase.LastName		= strSplit[strCnt] == null ? "" : strSplit[strCnt]; strCnt++;
				friendBase.Email		= strSplit[strCnt] == null ? "" : strSplit[strCnt]; strCnt++;
				friendBase.Gender		= (EGender)Convert.ToInt32(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

				return friendBase;
			}
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
			return this.ToString().GetHashCode();
		}

		public bool IsNull
		{
			get { return (mEmail.Length > 0); }
		}

		// Exceptions:
		//	System.ArgumentException:
		//		Other object is null
		//		The argument to compare is not a FriendBase
		//		Refering object (this) is null
		public int CompareTo(object other)
		{
			if (other == null)
				throw new System.ArgumentException("Other object is null", "other");

			FriendBaseBO friendBase = other as FriendBaseBO;

			if (friendBase == null)
				throw new System.ArgumentException("The argument to compare is not a friendBase", "other");


			return this.ToString().CompareTo(friendBase.ToString());
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
