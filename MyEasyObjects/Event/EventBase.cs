using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasy.Common;
using System.ComponentModel;
using MyEasyObjects.Resource;
using MyEasyObjects.User;
using MyEasyObjects.Item;
using MyEasyObjects.Object;
using System.Data.SqlTypes;
using MyEasyObjects.Holding;

namespace MyEasyObjects.Event
{
    public class EventBase : ResourceBase
    {
        #region Members

        EventBase mEventParent = null;

        List<EventBase> mEventChildren = new List<EventBase>();

        List<ItemBase> mItemChildren = new List<ItemBase>();

        EventTimeInfo mEventTimeInfo = null;

        ObjectLocation mEventLocation = new ObjectLocation();

        bool mIsPublic = false;

        EPrivacyType mPrivacyType = EPrivacyType.eProtected;

        #endregion

        #region Constructor

        public EventBase() :
            base(
                0,
                new UserBase(),
                new ResourceDescription())
        {
            mEventTimeInfo = new EventTimeInfo(0, DateTime.Now);
        }

        public EventBase(UInt64 uniqueID) :
            base(
                uniqueID,
                new UserBase(),
                new ResourceDescription(uniqueID))
        {
            mEventTimeInfo = new EventTimeInfo(uniqueID, DateTime.Now);
        }

        public EventBase(UInt64 uniqueID, UserBase adminUser) :
            base(
                uniqueID,
                adminUser,
                new ResourceDescription(uniqueID))
        {
            mEventTimeInfo = new EventTimeInfo(uniqueID, DateTime.Now);
        }

        public EventBase(
            UInt64 uniqueID,
            UserBase adminUser,
            ResourceDescription resourceDescription) :
            base(
                uniqueID,
                adminUser,
                resourceDescription)
        {
            mEventTimeInfo = new EventTimeInfo(uniqueID, DateTime.Now);
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
                    LastDALChange = 0;
                    mUniqueID = value;
                    mResourceDescription.OwnerUniqueID = value;
                    mEventTimeInfo.EventUniqueID = value;

                    OnPropertyChanged("EventBase.UniqueID.Changed");
                }
            }
        }

        public EventBase EventParent
        {
            get
            {
                if (mEventParent == null)
                    mEventParent = new EventBase();

                return mEventParent;
            }
            set
            {
                if (mEventParent != value)
                {
                    mEventParent = value;
                    ParentChanged();
                }
            }
        }

        public bool IsPublic
        {
            get { return mIsPublic; }
            set
            {
                if (mIsPublic != value)
                {
                    mIsPublic = value;
                    IsPublicChanged();
                }
            }
        }

        public EPrivacyType PrivacyType
        {
            get { return mPrivacyType; }
            set
            {
                if (mPrivacyType != value)
                {
                    mPrivacyType = value;
                }
            }
        }

        public List<EventBase> EventChildren
        {
            get { return mEventChildren; }
        }

        public List<ItemBase> ItemChildren
        {
            get { return mItemChildren; }
        }

        public EventTimeInfo EventTimeInfo
        {
            get { return mEventTimeInfo; }
            set
            {
                if (mEventTimeInfo != value)
                {
                    mEventTimeInfo = value;
                    EventTimeInfoChanged();
                }
            }
        }

        public ObjectLocation EventLocation
        {
            get { return mEventLocation; }
            set
            {
                if (mEventLocation != value)
                {
                    mEventLocation = value;
                    EventLocationChanged();
                }
            }
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

                if (EventParent == null)
                    retStr += mDelim + "0";
                else
                    retStr += mDelim + EventParent.UniqueID.ToString();

                retStr += mDelim + EventChildren.Count.ToString();
                for (int i = 0; i < EventChildren.Count; i++)
                    retStr += mDelim + EventChildren[i].UniqueID.ToString();

                retStr += mDelim + ItemChildren.Count.ToString();
                for (int i = 0; i < ItemChildren.Count; i++)
                    retStr += mDelim + ItemChildren[i].UniqueID.ToString();

                retStr += mDelim + EventTimeInfo.ToString();

                retStr += mDelim + EventLocation.ToString();

                retStr += mDelim + IsPublic.ToString();

                retStr += mDelim + PrivacyType.ToString();

                return retStr;
            }
        }

        public static EventBase Parse(string str)
        {
            int strCnt = 0;

            EventBase eventBase = new EventBase();

            string[] strSplit = null;
            strSplit = str.Split(new char[] { ';' });

            strCnt = ResourceBaseParse((ResourceBase)eventBase, strSplit, strCnt);

            strCnt = Parse(eventBase, strSplit, strCnt);

            return eventBase;
        }

        public static int Parse(EventBase eventBase, string[] strSplit, int strCnt)
        {
            int count = 0;

            UInt64 eventParentUniqueID = Convert.ToUInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

            if (eventParentUniqueID != 0)
                eventBase.EventParent = new EventBase(eventParentUniqueID);

            count = Convert.ToInt32(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;
            for (int i = 0; i < count; i++)
            {
                if (strSplit[strCnt] == null)
                    break;
                eventBase.EventChildren.Add(new EventBase(Convert.ToUInt64(strSplit[strCnt]))); strCnt++;
            }

            count = Convert.ToInt32(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;
            for (int i = 0; i < count; i++)
            {
                if (strSplit[strCnt] == null)
                    break;
                eventBase.ItemChildren.Add(new ItemBase(Convert.ToUInt64(strSplit[strCnt]))); strCnt++;
            }

            strCnt = EventTimeInfo.Parse(eventBase.EventTimeInfo, strSplit, strCnt);

            strCnt = ObjectLocation.Parse(eventBase.EventLocation, strSplit, strCnt);

            eventBase.IsPublic = Convert.ToBoolean(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

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

            EventBase eventBase = other as EventBase;

            if (eventBase == null)
                throw new System.ArgumentException("The argument to compare is not an EventBase", "other");

            if (IsNull)// || (!IsLoaded()))
                throw new System.ArgumentException("Refering object (this) is null", "this");

            return this.ToString().CompareTo(eventBase.ToString());
        }

        #endregion

        #region INotifyPropertyChanged Members

        private void ParentChanged() { OnPropertyChanged("EventBase.EventParent.Changed"); }

        private void IsPublicChanged() { OnPropertyChanged("EventBase.IsPublic.Changed"); }

        private void EventTimeInfoChanged() { OnPropertyChanged("EventBase.EventTimeInfo.Changed"); }

        private void EventLocationChanged() { OnPropertyChanged("EventBase.EventLocation.Changed"); }

        #endregion
    }
}
