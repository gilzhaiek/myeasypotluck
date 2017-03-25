using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasy.Common;
using System.ComponentModel;
using MyEasyObjects.Resource;
using System.Data.SqlTypes;
using System.IO;
using MyEasyObjects.Holding;
using MyEasyObjects.Object;
using System.Text.RegularExpressions;
using MyEasyObjects.Event;

namespace MyEasyObjects.User
{
    public class UserBase : MyObjectBase, INotifyPropertyChanged
    {
        #region Members

        string mFirstName = "";

        string mLastName = "";

        string mEmail = "";

        string mPhone = "";
        Regex mPhoneRegex = new Regex(@"^[0-9]*$");

        bool mFBUser = false;

        Int64 mLastFBSync = 0;

        EGender mGender = EGender.eGenderNull;

        ETitle mTitle = ETitle.eTitleNull;

        ObjectLocation mLocation = null;

        List<HoldingsInfo> mHoldingsInfo = new List<HoldingsInfo>();

        List<EventBase> mEvents = new List<EventBase>();

        #endregion

        public UserBase()
        {
            mLocation = new ObjectLocation();
        }

        public UserBase(UInt64 uniqueID)
            : base(uniqueID)
        {
            mLocation = new ObjectLocation(uniqueID);
        }

        #region properties

        public override UInt64 UniqueID
        {
            get { return mUniqueID; }
            set
            {
                if (mUniqueID != value)
                {
                    LastDALChange = 0;
                    mUniqueID = value;
                    OnPropertyChanged("UserBase.UniqueID.Changed");
                }
            }
        }

        public string FullName { get { return FirstName + " " + LastName; } }

        public string FirstName
        {
            get { return mFirstName; }
            set
            {
                if (mFirstName != value)
                {
                    mFirstName = value;
                    OnPropertyChanged("UserBase.FirstName.Changed");
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
                    OnPropertyChanged("UserBase.LastName.Changed");
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
                    OnPropertyChanged("UserBase.Email.Changed");
                }
            }
        }

        public string Phone
        {
            get { return mPhone; }
            set
            {
                if (!mPhoneRegex.IsMatch(value))
                {
                    // TODO - raise error
                    return;
                }

                if (mPhone != value)
                {
                    mPhone = value;
                    OnPropertyChanged("UserBase.Phone.Changed");
                }
            }
        }

        public ETitle? Title
        {
            get { return mTitle; }
            set
            {
                if (value == null)
                    mTitle = ETitle.eTitleNull;
                else if (mTitle != value.Value)
                {
                    mTitle = value.Value;
                    OnPropertyChanged("UserBase.Title.Changed");
                }
            }
        }

        public ObjectLocation Location
        {
            get { return mLocation; }
            set
            {
                if (mLocation != value)
                {
                    mLocation = value;
                    OnPropertyChanged("UserBase.Location.Changed");
                }
            }
        }

        public EGender? Gender
        {
            get { return mGender; }
            set
            {
                if (value == null)
                    mGender = EGender.eGenderNull;
                else if (mGender != value.Value)
                {
                    mGender = value.Value;
                    OnPropertyChanged("UserBase.Gender.Changed");
                }
            }
        }

        public bool FBUser
        {
            get { return mFBUser; }
            set
            {
                if (mFBUser != value)
                {
                    mFBUser = value;
                    OnPropertyChanged("UserBase.FBUser.Changed");
                }
            }
        }

        public Int64 LastFBSync
        {
            get { return mLastFBSync; }
            set
            {
                if (mLastFBSync != value)
                {
                    mLastFBSync = value;
                    OnPropertyChanged("UserBase.LastFBSync.Changed");
                }
            }
        }



        public List<HoldingsInfo> HoldingsInfo { get { return mHoldingsInfo; } }

        public List<EventBase> Events { get { return mEvents; } }

        #endregion

        #region Functions

        void PropertyChangedEvent(object sender, PropertyChangedEventArgs e)
        {
            if (sender == mHoldingsInfo)
                OnPropertyChanged("UserBase.HoldingsInfo.Changed");
            else if (sender == mEvents)
                OnPropertyChanged("UserBase.Events.Changed");
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

                retStr += mDelim + FirstName;
                retStr += mDelim + LastName;
                retStr += mDelim + Email;
                retStr += mDelim + Phone;
                retStr += mDelim + FBUser.ToString();
                retStr += mDelim + LastFBSync.ToString();
                retStr += mDelim + ((int)Gender).ToString();
                retStr += mDelim + ((int)Title).ToString();
                retStr += mDelim + mLocation.ToString();

                retStr += mDelim + HoldingsInfo.Count.ToString();
                for (int i = 0; i < HoldingsInfo.Count; i++)
                    retStr += mDelim + HoldingsInfo[i].UniqueID.ToString();

                retStr += mDelim + Events.Count.ToString();
                for (int i = 0; i < Events.Count; i++)
                    retStr += mDelim + Events[i].UniqueID.ToString();

                return retStr;
            }
        }

        public static UserBase Parse(SqlString sqlStr)
        {
            if (sqlStr.IsNull)
                return null;
            else
            {
                int strCnt = 0;
                int count = 0;

                UserBase userBase = new UserBase();

                string str = Convert.ToString(sqlStr);
                string[] strSplit = null;
                strSplit = str.Split(new char[] { ';' });

                userBase.UniqueID = Convert.ToUInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

                userBase.FirstName = strSplit[strCnt] == null ? "" : strSplit[strCnt]; strCnt++;
                userBase.LastName = strSplit[strCnt] == null ? "" : strSplit[strCnt]; strCnt++;
                userBase.Email = strSplit[strCnt] == null ? "" : strSplit[strCnt]; strCnt++;
                userBase.Phone = strSplit[strCnt] == null ? "" : strSplit[strCnt]; strCnt++;
                userBase.Gender = (EGender)Convert.ToInt32(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;
                userBase.Title = (ETitle)Convert.ToInt32(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;
                strCnt = ObjectLocation.Parse(userBase.Location, strSplit, strCnt);

                count = Convert.ToInt32(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;
                for (int i = 0; i < count; i++)
                {
                    if (strSplit[strCnt] == null)
                        break;
                    userBase.HoldingsInfo.Add(new HoldingsInfo(Convert.ToUInt64(strSplit[strCnt]))); strCnt++;
                }

                count = Convert.ToInt32(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;
                for (int i = 0; i < count; i++)
                {
                    if (strSplit[strCnt] == null)
                        break;
                    userBase.Events.Add(new EventBase(Convert.ToUInt64(strSplit[strCnt]))); strCnt++;
                }

                return userBase;
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
            if (IsNull)// || (!IsLoaded()))
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

            UserBase userBase = other as UserBase;

            if (userBase == null)
                throw new System.ArgumentException("The argument to compare is not a UserBase", "other");

            if (IsNull)// || (!IsLoaded()))
                throw new System.ArgumentException("Refering object (this) is null", "this");

            return this.ToString().CompareTo(userBase.ToString());
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
