using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasy.Common;
using MyEasyObjects.User;
using System.ComponentModel;
using MyEasyObjects.Resource;
using MyEasyObjects.Holding;
using System.IO;
using System.Data.SqlTypes;
using MyEasyObjects.Object;


namespace MyEasyObjects.Resource
{
    public class ResourceBase : MyObjectBase, INotifyPropertyChanged
    {
        #region Members

        // TODO - change this to list
        protected UserBase mAdmin = null;

        EHoldingPermissions mCurrentUserHoldingPermissions = EHoldingPermissions.eHoldingPermissionsNull;

        protected ResourceDescription mResourceDescription = null;

        protected EResourcePriority mResourcePriority = EResourcePriority.eResourcePriorityNull;

        protected int mMaxHoldings = 10000;

        protected List<HoldingsInfo> mHoldingsInfo = new List<HoldingsInfo>();

        protected bool mScalable = false;

        protected int mValue = 0;

        protected NameImage mThumbNameImage = null;

        protected NameImage mFullNameImage = null;

        #endregion

        #region Constructor

        public ResourceBase()
        {
            InitResourceBase(
                0,
                new UserBase(),
                new ResourceDescription(),
                new NameImage(),
                new NameImage());
        }

        public ResourceBase(UInt64 uniqueID)
        {
            InitResourceBase(
                uniqueID,
                new UserBase(),
                new ResourceDescription(uniqueID),
                new NameImage(),
                new NameImage());
        }

        public ResourceBase(UInt64 uniqueID, UserBase adminUser)
        {
            InitResourceBase(
                uniqueID,
                adminUser,
                new ResourceDescription(uniqueID),
                new NameImage(),
                new NameImage());
        }

        public ResourceBase(
            UInt64 uniqueID,
            UserBase adminUser,
            ResourceDescription resourceDescription)
        {
            InitResourceBase(
                uniqueID,
                adminUser,
                resourceDescription,
                new NameImage(),
                new NameImage());
        }

        public ResourceBase(
            UInt64 uniqueID,
            UserBase adminUser,
            ResourceDescription resourceDescription,
            NameImage fullNameImage,
            NameImage thumbNameImage)
        {
            InitResourceBase(
                uniqueID,
                adminUser,
                resourceDescription,
                fullNameImage,
                thumbNameImage);
        }

        private void InitResourceBase(
            UInt64 uniqueID,
            UserBase adminUser,
            ResourceDescription resourceDescription,
            NameImage fullNameImage,
            NameImage thumbNameimage)
        {
            mUniqueID = uniqueID;
            mAdmin = adminUser;
            mResourceDescription = resourceDescription;
            mResourcePriority = MyEasySettings.DefaultResourcePriority;
            mHoldingsInfo.Clear();
            mScalable = false;
            mFullNameImage = fullNameImage;
            mThumbNameImage = thumbNameimage;
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
                    OnPropertyChanged("ResourceBase.UniqueID.Changed");
                }
            }
        }

        public UserBase Admin
        {
            get { return mAdmin; }
            set
            {
                if (mAdmin != value)
                {
                    mAdmin = value;
                    AdminChanged();
                }
            }
        }

        public EHoldingPermissions CurrentUserHoldingPermissions
        {
            get { return mCurrentUserHoldingPermissions; }
            set { mCurrentUserHoldingPermissions = value; }
        }

        public ResourceDescription ResourceDescription
        {
            get { return mResourceDescription; }
            set
            {
                if (mResourceDescription != value)
                {
                    mResourceDescription = value;
                    DescriptionChanged();
                }
            }
        }

        public EResourcePriority ResourcePriority
        {
            get { return mResourcePriority; }
            set
            {
                if (mResourcePriority != value)
                {
                    mResourcePriority = value;
                    PriorityChanged();
                }
            }
        }

        public int MaxHoldings
        {
            get { return mMaxHoldings; }
            set
            {
                if (mMaxHoldings != value)
                {
                    mMaxHoldings = value;
                    MaxHoldingsChanged();
                }
            }
        }

        public List<HoldingsInfo> HoldingsInfo
        {
            get { return mHoldingsInfo; }
        }

        public bool Scalable
        {
            get { return mScalable; }
            set
            {
                if (mScalable != value)
                {
                    mScalable = value;
                    ScalableChanged();
                }
            }
        }

        public int Value
        {
            get { return mValue; }
            set
            {
                if (mValue != value)
                {
                    mValue = value;
                    ValueChanged();
                }
            }
        }

        public string ThumbName
        {
            get { return mThumbNameImage.Name; }
            set
            {
                if (mThumbNameImage.Name != value)
                {
                    mThumbNameImage.Name = value;
                    ThumbNameChanged();
                }
            }
        }

        public string ThumbImageLocation
        {
            get { return mThumbNameImage.ImageLocation; }
            set
            {
                if (mThumbNameImage.ImageLocation != value)
                {
                    mThumbNameImage.ImageLocation = value;
                    ThumbImageLocationChanged();
                }
            }
        }


        public NameImage ThumbNameImage
        {
            get { return mThumbNameImage; }
            set
            {
                if (mThumbNameImage != value)
                {
                    mThumbNameImage = value;
                    ThumbNameImageChanged();
                }
            }
        }

        public string FullName
        {
            get { return mFullNameImage.Name; }
            set
            {
                if (mFullNameImage.Name != value)
                {
                    mFullNameImage.Name = value;
                    FullNameChanged();
                }
            }
        }

        public string FullImageLocation
        {
            get { return mFullNameImage.ImageLocation; }
            set
            {
                if (mFullNameImage.ImageLocation != value)
                {
                    mFullNameImage.ImageLocation = value;
                    FullImageLocationChanged();
                }
            }
        }


        public NameImage FullNameImage
        {
            get { return mFullNameImage; }
            set
            {
                if (mFullNameImage != value)
                {
                    mFullNameImage = value;
                    FullNameImageChanged();
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

                retStr += mDelim + Admin.UniqueID.ToString();

                retStr += mDelim + ResourceDescription.ToString();

                retStr += mDelim + ((int)ResourcePriority).ToString();

                retStr += mDelim + MaxHoldings.ToString();

                retStr += mDelim + HoldingsInfo.Count.ToString();
                for (int i = 0; i < HoldingsInfo.Count; i++)
                    retStr += mDelim + HoldingsInfo[i].UniqueID.ToString();

                retStr += mDelim + Scalable.ToString();

                retStr += mDelim + mValue.ToString();

                retStr += mDelim + mThumbNameImage.ToString();

                retStr += mDelim + mFullNameImage.ToString();


                return retStr;
            }
        }

        public static int ResourceBaseParse(ResourceBase resourceBase, string[] strSplit, int strCnt)
        {
            int count = 0;

            resourceBase.UniqueID = Convert.ToUInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

            resourceBase.Admin = new UserBase(Convert.ToUInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt])); strCnt++;

            strCnt = ResourceDescription.Parse(resourceBase.ResourceDescription, strSplit, strCnt);

            resourceBase.ResourcePriority = (EResourcePriority)Convert.ToInt32(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

            resourceBase.MaxHoldings = Convert.ToInt32(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

            count = Convert.ToInt32(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;
            for (int i = 0; i < count; i++)
            {
                if (strSplit[strCnt] == null)
                    break;
                resourceBase.HoldingsInfo.Add(new HoldingsInfo(Convert.ToUInt64(strSplit[strCnt]))); strCnt++;
            }

            resourceBase.Scalable = Convert.ToBoolean(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

            resourceBase.Value = Convert.ToInt32(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

            strCnt = NameImage.Parse(resourceBase.ThumbNameImage, strSplit, strCnt);

            strCnt = NameImage.Parse(resourceBase.FullNameImage, strSplit, strCnt);

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

            ResourceBase resourceBase = other as ResourceBase;

            if (resourceBase == null)
                throw new System.ArgumentException("The argument to compare is not a resourceBase", "other");

            if (IsNull)// || (!IsLoaded()))
                throw new System.ArgumentException("Refering object (this) is null", "this");

            return this.ToString().CompareTo(resourceBase.ToString());
        }

        #endregion

        #region INotifyPropertyChanged Members

        private void AdminChanged() { OnPropertyChanged("ResourceBase.Admin.Changed"); }

        private void DescriptionChanged() { OnPropertyChanged("ResourceBase.ResourceDescription.Changed"); }

        private void PriorityChanged() { OnPropertyChanged("ResourceBase.ResourcePriority.Changed"); }

        private void MaxHoldingsChanged() { OnPropertyChanged("ResourceBase.MaxHoldings.Changed"); }

        private void ScalableChanged() { OnPropertyChanged("ResourceBase.Scalable.Changed"); }

        private void ValueChanged() { OnPropertyChanged("ResourceBase.Value.Changed"); }

        private void FullNameChanged() { OnPropertyChanged("ResourceBase.FullName.Changed"); }
        private void FullImageLocationChanged() { OnPropertyChanged("ResourceBase.FullImageLocation.Changed"); }
        private void FullNameImageChanged() { OnPropertyChanged("ResourceBase.FullNameImage.Changed"); }

        private void ThumbNameChanged() { OnPropertyChanged("ResourceBase.ThumbName.Changed"); }
        private void ThumbImageLocationChanged() { OnPropertyChanged("ResourceBase.ThumbImageLocation.Changed"); }
        private void ThumbNameImageChanged() { OnPropertyChanged("ResourceBase.ThumbNameImage.Changed"); }

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
